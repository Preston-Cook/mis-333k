using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

using Candid.DAL;
using Candid.Models;
using Candid.Utilities;
using Microsoft.EntityFrameworkCore;
using Candid.Services.EmailService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Candid.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        public AdminController(AppDbContext appDbContext, UserManager<AppUser> userManager, IEmailService emailService)
        {
            _context = appDbContext;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            ViewBag.SystemDate = CurrentUser.SystemDate;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSystemDate(DateTime SystemDate)
        {

            // Get each user
            foreach (var User in _context.Users)
            {
                // Change user's system date to system date in POST data
                User.SystemDate = SystemDate;
            }

            // Save changes in db
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Admin");
        }

        public async Task<IActionResult> Students(String? q)
        {
            IIncludableQueryable<AppUser, Major> Students = await AppUserExtensions.GetAllStudents(_context, IncludeDeactivated: true);

            if (q != null)
            {
                Students = Students.Where(s => s.FirstName.ToLower().Contains(q.ToLower()) || s.LastName.ToLower().Contains(q.ToLower()))
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }

            return View(Students);
        }

        [HttpGet]
        public IActionResult DetailedStudentSearch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailedStudentSearch(StudentSearchViewModel ssvm)
        {
            if (!ModelState.IsValid)
            {
                return View(ssvm);
            }

            var Students = await AppUserExtensions.SearchStudents(ssvm, _context, IncludeDeactivated: true);

            return View("Students", Students);
        }

        [HttpGet]
        public async Task<IActionResult> StudentDetails(String? Id)
        {
            // Redirect user to students if no id provided
            if (Id == null)
            {
                return RedirectToAction("Students", "Admin");
            }

            // Get student by id with naviational properties
            var Student = await AppUserExtensions.GetStudentById(Id, _context, IncludeDeactivated: true);

            // Check if student is null and return 404 page if so
            if (Student == null)
            {
                return NotFound();
            }

            var Roles = await _userManager.GetRolesAsync(Student);

            // Ensure page is tied to a student
            if (Roles.First() != "Student")
            {
                return BadRequest();
            }

            // Get all of user's applications where they have been accepted for interviews and deadline passed
            var apps = _context.AppUserPositions
                .Where(aup => aup.StatusType == StatusType.Accepted && aup.Position.Deadline < Student.SystemDate && aup.StudentId == Student.Id)
                .Include(aup => aup.Position)
                .ThenInclude(p => p.Company);

            List<SelectListItem> SelectList = new List<SelectListItem>();

            foreach (var app in apps)
            {
                SelectList.Add(new SelectListItem { Text = $"{app.Position.Company.CompanyName}: {app.Position.PositionName}", Value = $"{app.AppUserPositionId}" });
            }

            ViewBag.SelectList = SelectList;

            // Pass student object to view
            return View(new AdminStudentViewModel
            {
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                FormattedMajors = String.Join(", ", Student.AppUserMajors.Where(aum => aum.isActive).Select(aup => Utilities.EnumExtensions.GetDisplayName(aup.Major.MajorCode))),
                GPA = Student.GPA,
                FormattedEthnicity = EnumExtensions.GetDisplayName(Student.Ethnicity),
                FormattedGender = EnumExtensions.GetDisplayName(Student.Gender),
                FormattedAddress = $"{Student.Address.Street} {Student.Address.City}, {Student.Address.State} {Student.Address.PostalCode}",
                FormattedGraduationDate = Student.GraduationDate.HasValue ? Student.GraduationDate.Value.ToString("MMMM dd, yyyy") : "",
                IsActive = Student.IsActive,
                StudentId = Student.Id
            });
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent(StudentRegisterModel studentRegisterModel)
        {
            // Try to add user and catch exception if fail
            if (!ModelState.IsValid)
            {
                return View(studentRegisterModel);
            }

            String UserId;
            try
            {
                UserId = await AppUserExtensions.CreateUser(studentRegisterModel, _userManager, _context);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Account Already Exists");
                return View(studentRegisterModel);
            }

            _emailService.SendEmail(new EmailDTO { To = studentRegisterModel.Email, Subject = "Welcome To Your Candid Account!", Body = $$"""Hi {{studentRegisterModel.FirstName}},\r\n\r\nWe\'re excited to have you on board with Candid! Our platform is designed to help students like you find the perfect job or internship opportunity.\r\n\r\nAs a new member, we encourage you to complete your profile as soon as possible to start exploring job postings and connecting with potential employers. If you need any assistance, please feel free to reach out to our support team at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nThe Candid Team\r\n""" });

            // Redirect to all students page
            return RedirectToAction("StudentDetails", "Admin", new { Id = UserId });
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(String? Id)
        {
            // Redirect user to all students page is no id is specified
            if (Id == null)
            {
                return RedirectToAction("Students", "Admin");
            }

            // Retrieve student from database
            var student = await AppUserExtensions.GetStudentById(Id, _context, IncludeDeactivated: true);

            // Check if student does not exist
            if (student == null)
            {
                return NotFound();
            }

            // Ensure requested user is in student role
            var Roles = await _userManager.GetRolesAsync(student);

            if (Roles.First() != "Student")
            {
                return NotFound();
            }

            var srvm = AppUserExtensions.CreateUserStudentViewModel(student);

            return View(srvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(StudentViewModel svm)
        {
            if (!ModelState.IsValid)
            {
                return View(svm);
            }

            // Apply edits to student
            var Student = await AppUserExtensions.GetStudentById(svm.StudentId, _context, IncludeDeactivated: true);

            if (Student == null)
            {
                return BadRequest();
            }

            // Ensure requested user is in student role
            var Roles = await _userManager.GetRolesAsync(Student);

            if (Roles.First() != "Student")
            {
                return BadRequest();
            }

            Student.FirstName = svm.FirstName;
            Student.LastName = svm.LastName;

            foreach (var aum in Student.AppUserMajors)
            {
                aum.isActive = false;
            }

            foreach (var MajorCode in svm.Majors)
            {
                var Major = await _context.Majors.FirstOrDefaultAsync(m => m.MajorCode == MajorCode);
                var MajorId = Major.MajorId;

                var UserMajor = await _context.AppUserMajors.FirstOrDefaultAsync(aum => aum.AppUserId == svm.StudentId && aum.MajorId == MajorId);

                if (UserMajor != null)
                {
                    UserMajor.isActive = true;
                }
                else
                {
                    await _context.AppUserMajors.AddAsync(new AppUserMajor { AppUserId = Student.Id, MajorId = MajorId });
                }
            }

            Student.GraduationDate = svm.GraduationDate;
            Student.GPA = svm.GPA;
            Student.Ethnicity = svm.Ethnicity;
            Student.Gender = svm.Gender;
            Student.PositionType = svm.PositionType;

            // Call utility method to get Address Id
            Student.AddressId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = svm.Street, City = svm.City, PostalCode = svm.PostalCode, State = svm.State }, _context);

            await _context.SaveChangesAsync();

            return RedirectToAction("StudentDetails", "Admin", new { Id = Student.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateStudent(String? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var Student = await AppUserExtensions.GetStudentById(Id, _context, IncludeDeactivated: true);

            if (Student == null)
            {
                return BadRequest();
            }

            // Ensure Requested User is a student
            var Roles = await _userManager.GetRolesAsync(Student);

            if (Roles.First() != "Student")
            {
                return BadRequest();
            }

            // Activate if student deactivated and deactivate if active
            Student.IsActive = !Student.IsActive;
            await _context.SaveChangesAsync();

            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            if (Student.IsActive)
            {
                _emailService.SendEmail(new EmailDTO { To = Student.Email, Subject = $"Your Candid Student Account Has Been Reactivated", Body = $$"""Dear {{Student.FirstName}} {{Student.LastName}},\r\n\r\nWe are pleased to inform you that your Candid student account has been reactivated. You can now log in to your account and access all the features and functionalities of our platform. We apologize for any inconvenience caused by the deactivation of your account, and we appreciate your patience and understanding during this time.\r\n\r\nIf you have any questions or concerns about your account reactivation or the status of your job applications, please don\'t hesitate to contact our support team at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}. We are always happy to help you.\r\n\r\nThank you for using Candid, and we wish you the best of luck with your job search!\r\n\r\nBest regards,\r\nThe Candid Team""" });
            }
            else
            {
                _emailService.SendEmail(new EmailDTO { To = CurrentUser.Email, Subject = $"Subject Line: Account Deactivated: {Student.FirstName} {Student.LastName} - {Student.Email}", Body = $$"""Hi,\r\n\r\nThe account for {{Student.FirstName}} {{Student.LastName}} with the email address {{Student.Email}} has been deactivated on Candid . Please ensure that all relevant information has been saved and the user\'s access has been revoked.\r\n\r\nIf you have any questions or concerns, please don\'t hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid  Team\r\n""" });
                _emailService.SendEmail(new EmailDTO { To = Student.Email, Subject = $"Notice: Your Candid Account has been Deactivated", Body = $$"""Dear {{Student.FirstName}},\r\n\r\nWe are writing to inform you that your account on Candid has been deactivated. This may be due to a violation of our terms of service, a violation of our community guidelines, or inactivity for an extended period.\r\n\r\nWe understand that this may come as a surprise, and we apologize for any inconvenience this may cause. We encourage you to review our terms of service and community guidelines to ensure that you are aware of our policies and guidelines for using Candid.\r\n\r\nIf you believe that your account has been deactivated in error, or if you have any questions or concerns, please contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nThank you for being a part of the Candid community, and we wish you all the best in your future endeavors.\r\n\r\nBest regards,\r\n\r\nThe Candid Team""" });
            }

            return RedirectToAction("StudentDetails", "Admin", new { Id = Id });
        }

        [HttpGet]
        public async Task<IActionResult> Recruiters()
        {
            return View(await AppUserExtensions.GetAllRecruiters(_context, IncludeDeactivated: true));
        }

        [HttpGet]
        public async Task<IActionResult> RecruiterDetails(String? Id)
        {
            // Redirect user to students if no id provided
            if (Id == null)
            {
                return RedirectToAction("Recruiters", "Admin");
            }

            // Get recruiter by id with naviational properties
            var Recruiter = await AppUserExtensions.GetRecruiterById(Id, _context, IncludeDeactivated: true);

            // Check if recruiter is null and return 404 page if so
            if (Recruiter == null)
            {
                return NotFound();
            }

            // Ensure recruiter is in recruiter role
            var Roles = await _userManager.GetRolesAsync(Recruiter);

            if (Roles.First() != "Recruiter")
            {
                return BadRequest();
            }

            // Pass recruiter object to view
            return View(Recruiter);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRecruiter()
        {
            ViewBag.CompanyList = await _context.Companies.Where(c => c.CompanyName.ToLower() != "candid").OrderBy(c => c.CompanyName).Select(c => c.CompanyName).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRecruiter(RecruiterRegisterModel rrm)
        {
            if (!ModelState.IsValid)
            {
                return View(rrm);
            }

            var Company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == rrm.CompanyName);

            if (Company == null)
            {
                ModelState.AddModelError("", "Invalid Company Name");
                return View(rrm);
            }

            String UserId;
            try
            {
                UserId = await AppUserExtensions.CreateUser(rrm, _userManager, _context);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Recruiter Already Exists");
                return View(rrm);
            }

            _emailService.SendEmail(new EmailDTO { To = rrm.Email, Subject = $"Welcome to Candid , {rrm.FirstName}!", Body = $$"""Hi {{rrm.FirstName}},\r\n\r\nWelcome to Candid! Our platform is designed to help recruiters like you find the best candidates for your job postings.\r\n\r\nAs a new member, we encourage you to explore our platform and post any job opportunities you have available. If you have any questions or concerns, please don\'t hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nThe Candid Team\r\n""" });
            TwilioExtensions.SendMessage($"Hi {rrm.FirstName},\r\n\r\nThank you for registering on Candid! Your account has been created successfully. You can now start searching for talented students to fill your job openings. To get started, please log in to your account and post your job listings. If you have any questions or issues, please contact our support team at {System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}.\r\n\r\nWe look forward to helping you find the best candidates for your open positions.\r\n\r\nBest regards,\r\nThe Candid Team", "");

            return RedirectToAction("RecruiterDetails", "Admin", new { Id = UserId });
        }

        [HttpGet]
        public async Task<IActionResult> EditRecruiter(String? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Recruiters", "Admin");
            }

            var Recruiter = await AppUserExtensions.GetRecruiterById(Id, _context, IncludeDeactivated: true);

            if (Recruiter == null)
            {
                return NotFound();
            }

            // Ensure requested user in role 
            var Roles = await _userManager.GetRolesAsync(Recruiter);

            if (Roles.First() != "Recruiter")
            {
                return NotFound();
            }

            var rvm = AppUserExtensions.CreateUserRecruiterViewModel(Recruiter);
            var CompanyList = await _context.Companies.Where(c => c.CompanyName.ToLower() != "candid").OrderBy(c => c.CompanyName).Select(c => c.CompanyName).ToListAsync();

            ViewBag.CompanyList = CompanyList;

            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecruiter(RecruiterViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CompanyList = await _context.Companies.OrderBy(c => c.CompanyName).Select(c => c.CompanyName).ToListAsync();
                return View(rvm);
            }

            // Get recruiter
            var Recruiter = await AppUserExtensions.GetRecruiterById(rvm.RecruiterId, _context, IncludeDeactivated: true);

            if (Recruiter == null)
            {
                return BadRequest();
            }

            // Ensure requested user is a recruiter
            var Roles = await _userManager.GetRolesAsync(Recruiter);

            if (Roles.First() != "Recruiter")
            {
                return BadRequest();
            }

            // Get Recruiter's new company
            var Company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == rvm.CompanyName);

            if (Company == null)
            {
                return BadRequest();
            }

            Recruiter.FirstName = rvm.FirstName;
            Recruiter.LastName = rvm.LastName;
            Recruiter.CompanyId = Company.CompanyId;

            await _context.SaveChangesAsync();

            return RedirectToAction("RecruiterDetails", "Admin", new { Id = Recruiter.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateRecruiter(String? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var Recruiter = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (Recruiter == null)
            {
                return BadRequest();
            }

            // Ensure requested user is in admin role
            var Roles = await _userManager.GetRolesAsync(Recruiter);

            if (Roles.First() != "Recruiter")
            {
                return BadRequest();
            }

            Recruiter.IsActive = !Recruiter.IsActive;
            await _context.SaveChangesAsync();

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            if (Recruiter.IsActive)
            {
                _emailService.SendEmail(new EmailDTO { To = Recruiter.Email, Subject = "Your Candid Recruiter Account Has Been Reactivated", Body = $$"""Dear {{Recruiter.FirstName}} {{Recruiter.LastName}},\r\n\r\nWe are pleased to inform you that your Candid recruiter account has been reactivated. You can now log in to your account and access all the features and functionalities of our platform. We apologize for any inconvenience caused by the deactivation of your account, and we appreciate your patience and understanding during this time.\r\n\r\nIf you have any questions or concerns about your account reactivation or the status of your job postings, please don\'t hesitate to contact our support team at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}. We are always happy to help you.\r\n\r\nThank you for using Candid, and we hope you have a great experience on our platform!\r\n\r\nBest regards,\r\nThe Candid Team""" });
            }
            else
            {
                _emailService.SendEmail(new EmailDTO { To = CurrentUser.Email, Subject = $"Account Deactivated: {Recruiter.FirstName} {Recruiter.LastName} - {Recruiter.Email}", Body = $$"""Hi,\r\n\r\nThe account for {{Recruiter.FirstName}} {{Recruiter.LastName}} with the email address {{Recruiter.Email}} has been deactivated on Candid. Please ensure that all relevant information has been saved and the user\'s access has been revoked.\r\n\r\nIf you have any questions or concerns, please don\'t hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n""" });
                _emailService.SendEmail(new EmailDTO { To = Recruiter.Email, Subject = "Notice: Your Candid Account has been Deactivated", Body = $$"""Dear {{Recruiter.FirstName}},\r\n\r\nWe are writing to inform you that your account on Candid has been deactivated. This may be due to a violation of our terms of service, a violation of our community guidelines, or inactivity for an extended period.\r\n\r\nWe understand that this may come as a surprise, and we apologize for any inconvenience this may cause. We encourage you to review our terms of service and community guidelines to ensure that you are aware of our policies and guidelines for using Candid.\r\n\r\nIf you believe that your account has been deactivated in error, or if you have any questions or concerns, please contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nThank you for being a part of the Candid community, and we wish you all the best in your future recruitment endeavors.\r\n\r\nBest regards,\r\n\r\nThe Candid Team""" });
            }

            return RedirectToAction("RecruiterDetails", "Admin", new { Id = Id });
        }

        [HttpGet]
        public IActionResult Employers(String? q)
        {
            IIncludableQueryable<Company, Industry> Companies;

            if (q == null)
            {
                Companies = CompanyExtensions.GetAllCompanies(_context, IncludeDeactivated: false);
            }
            else
            {
                Companies = CompanyExtensions.BasicSearchCompanies(q, _context, IncludeDeactivated: false);
            }

            return View(Companies.OrderBy(c => c.CompanyName));
        }

        [HttpGet]
        public IActionResult DetailedEmployerSearch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailedEmployerSearch(CompanySearchViewModel csvm)
        {
            if (!ModelState.IsValid)
            {
                return View(csvm);
            }

            var Companies = CompanyExtensions.SearchCompanies(csvm, _context, IncludeDeativated: false);

            return View("Employers", Companies);
        }

        [HttpGet]
        public async Task<IActionResult> EmployerDetails(Int32? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Employers", "Admin");
            }

            var Company = await CompanyExtensions.GetCompanyById(_context, (Int32)Id, IncludeDeactivated: true);

            if (Company == null)
            {
                return NotFound();
            }

            return View(Company);
        }

        [HttpGet]
        public IActionResult CreateEmployer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployer(CompanyViewModel ccvm)
        {
            if (!ModelState.IsValid)
            {
                return View(ccvm);
            }

            // Check if company name already exists
            var company = _context.Companies.FirstOrDefault(c => c.CompanyName == ccvm.CompanyName);

            if (company != null)
            {
                ModelState.AddModelError("", "Company already exists");
                return View(ccvm);
            }

            // Call utility method to get Address ID
            var addrId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = ccvm.Street, City = ccvm.City, State = ccvm.State, PostalCode = ccvm.PostalCode }, _context);

            // Create Company
            var NewCompany = new Company
            {
                AddressId = addrId,
                CompanyName = ccvm.CompanyName,
                CompanyEmail = ccvm.CompanyEmail,
                WebsiteUrl = ccvm.WebsiteUrl,
                CompanyDescription = ccvm.CompanyDescription
            };

            // Add company to database
            await _context.AddAsync(NewCompany);

            // Save company to database
            await _context.SaveChangesAsync();

            // Add company's industries
            foreach (var IndustryType in ccvm.IndustryTypes)
            {
                var Industry = await _context.Industries.FirstOrDefaultAsync(i => i.IndustryType == IndustryType);
                await _context.AddAsync(new CompanyIndustry { CompanyId = NewCompany.CompanyId, IndustryId = Industry.IndustryId });
            }

            await _context.SaveChangesAsync();

            // Redirect user to all employers page
            return RedirectToAction("EmployerDetails", "Admin", new { Id = NewCompany.CompanyId });
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployer(Int32? Id)
        {
            if (Id == null)
            {
                return RedirectToActionPermanent("Employers", "Admin");
            }

            var Company = await CompanyExtensions.GetCompanyById(_context, (Int32)Id, IncludeDeactivated: true);

            if (Company == null)
            {
                return NotFound();
            }

            var cvm = CompanyExtensions.CreateCompanyViewModel(Company);

            return View(cvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployer(CompanyViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            var Company = await CompanyExtensions.GetCompanyById(_context, (Int32)cvm.CompanyId, IncludeDeactivated: true);

            var SameName = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName.ToLower() == cvm.CompanyName.ToLower() && c.CompanyId != cvm.CompanyId);

            if (SameName != null)
            {
                ModelState.AddModelError("", "Another Company of this Name Already Exists");
                return View(cvm);
            }

            foreach (var CompanyIndustry in _context.CompanyIndustries.Where(ci => ci.CompanyId == Company.CompanyId))
            {
                CompanyIndustry.isActive = false;
            }

            foreach (var IndustryType in cvm.IndustryTypes)
            {
                // Get Id for industry type
                var Industry = await _context.Industries.Where(i => i.IndustryType == IndustryType).FirstOrDefaultAsync();
                var IndustryId = Industry.IndustryId;

                var CompanyIndustry = await _context.CompanyIndustries.Where(ci => ci.IndustryId == IndustryId && ci.CompanyId == Company.CompanyId).FirstOrDefaultAsync();

                if (CompanyIndustry != null)
                {
                    CompanyIndustry.isActive = true;
                }
                else
                {
                    await _context.CompanyIndustries.AddAsync(new CompanyIndustry { CompanyId = Company.CompanyId, IndustryId = IndustryId });
                }
            }

            Company.AddressId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = cvm.Street, City = cvm.City, PostalCode = cvm.PostalCode, State = cvm.State }, _context);

            // Add additional properties to company
            Company.CompanyName = cvm.CompanyName;
            Company.CompanyEmail = cvm.CompanyEmail;
            Company.WebsiteUrl = cvm.WebsiteUrl;
            Company.CompanyDescription = cvm.CompanyDescription;


            await _context.SaveChangesAsync();

            return RedirectToAction("EmployerDetails", "Admin", new { Id = Company.CompanyId });
        }

        [HttpGet]
        public async Task<IActionResult> Jobs(String? q)
        {

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            IIncludableQueryable<Position, Major> Positions;

            if (q == null)
            {
                Positions = PositionExtensions.GetAllPositions(_context, PastDate: null, IncludeDeativated: true);
            }
            else
            {
                Positions = _context.Positions
                    .Where(p => p.PositionName.ToLower().Contains(q.ToLower()) || p.Company.CompanyName.ToLower().Contains(q.ToLower()))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            // Create dictionary hash table of company industries
            Dictionary<string, string> CompanyIndustries = new Dictionary<string, string>();
            
            var Companies = _context.Companies
                .Include(c => c.CompanyIndustries)
                .ThenInclude(c => c.Industry);
            
            foreach (var Company in Companies)
            {
                string FormattedCompanyIndustries = String.Join(", ", Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => Candid.Utilities.EnumExtensions.GetDisplayName(ci.Industry.IndustryType)));
                CompanyIndustries.Add(Company.CompanyName, FormattedCompanyIndustries);
            }

            ViewBag.CompanyIndustries = CompanyIndustries;


            // Return positions to view
            return View(Positions);
        }

        [HttpGet]
        public IActionResult DetailedJobSearch()
        {
            List<SelectListItem> SelectList = new List<SelectListItem>();

            var Companies = _context.Companies.OrderBy(c => c.CompanyName);

            foreach (var Company in Companies)
            {
                SelectList.Add(new SelectListItem { Text = Company.CompanyName, Value = $"{Company.CompanyId}" });
            }

            ViewBag.SelectList = SelectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailedJobSearch(PositionSearchViewModel psvm)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> SelectList = new List<SelectListItem>();

                var Names = _context.Companies.OrderBy(c => c.CompanyName);

                foreach (var Company in Names)
                {
                    SelectList.Add(new SelectListItem { Text = Company.CompanyName, Value = $"{Company.CompanyId}" });
                }

                ViewBag.SelectList = SelectList;

                return View(psvm);
            }

            Dictionary<string, string> CompanyIndustries = new Dictionary<string, string>();
            
            var Companies = _context.Companies
                .Include(c => c.CompanyIndustries)
                .ThenInclude(c => c.Industry);
            
            foreach (var Company in Companies)
            {
                string FormattedCompanyIndustries = String.Join(", ", Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => Candid.Utilities.EnumExtensions.GetDisplayName(ci.Industry.IndustryType)));
                CompanyIndustries.Add(Company.CompanyName, FormattedCompanyIndustries);
            }

            ViewBag.CompanyIndustries = CompanyIndustries;

            // Get current user's system date
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var Positions = PositionExtensions.SearchPositions(psvm, _context, IncludeDeactivated: true);

            return View("Jobs", Positions);
        }

        [HttpGet]
        public async Task<IActionResult> CreateJob()
        {
            ViewBag.CompanyList = await _context.Companies.Where(c => c.CompanyName.ToLower() != "candid").OrderBy(c => c.CompanyName).Select(c => c.CompanyName).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJob(AdminPositionViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CompanyList = await _context.Companies.Select(c => c.CompanyName).ToListAsync();
                return View(pvm);
            }

            var Company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == pvm.CompanyName);

            if (Company == null)
            {
                return BadRequest();
            }

            // Get all positions from company
            var SameName = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName.ToLower() == pvm.PositionName.ToLower() && p.CompanyId == Company.CompanyId);

            if (SameName != null)
            {
                ViewBag.CompanyList = await _context.Companies.Select(c => c.CompanyName).ToListAsync();
                ModelState.AddModelError("", "Position with this Name Already Exists");
                return View(pvm);
            }

            pvm.CompanyId = Company.CompanyId;

            Int32 PositionId;
            try
            {
                PositionId = await PositionExtensions.CreatePosition(pvm, _context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("", "Position already exists");
                return View(pvm);
            }

            return RedirectToAction("JobDetails", "Admin", new { Id = PositionId });
        }

        [HttpGet]
        public async Task<IActionResult> JobDetails(Int32? Id)
        {

            // If id is null, redirect to page with all positions
            if (Id == null)
            {
                return RedirectToAction("Jobs", "Admin");
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Get position by ID that is not deactivated and is not past deadline
            var Pos = await PositionExtensions.GetPositionById((Int32)Id, _context, IncludeDeativated: true);

            // Check if Position Id exists in database within proper contraints
            if (Pos == null)
            {
                return NotFound();
            }

            // Return position
            return View(Pos);
        }

        [HttpGet]
        public async Task<IActionResult> EditJob(Int32? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Jobs", "Admin");
            }

            var Position = await PositionExtensions.GetPositionById((Int32)Id, _context, IncludeDeativated: true);

            if (Position == null)
            {
                return NotFound();
            }

            var pvm = PositionExtensions.CreatePositionViewModel(Position);

            return View(pvm);
        }

        [HttpPost]
        public async Task<IActionResult> EditJob(PositionViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                return View(pvm);
            }

            var Position = await PositionExtensions.GetPositionById(pvm.PositionId, _context, IncludeDeativated: true);

            foreach (var PositionMajor in _context.PositionMajors.Where(pm => pm.PositionId == Position.PositionId))
            {
                PositionMajor.isActive = false;
            }

            foreach (var MajorCode in pvm.Majors)
            {
                var Major = await _context.Majors.Where(m => m.MajorCode == MajorCode).FirstOrDefaultAsync();
                var MajorId = Major.MajorId;

                var PositionMajor = await _context.PositionMajors.Where(pm => pm.MajorId == MajorId && pm.PositionId == Position.PositionId).FirstOrDefaultAsync();

                if (PositionMajor != null)
                {
                    PositionMajor.isActive = true;
                }
                else
                {
                    await _context.PositionMajors.AddAsync(new PositionMajor { PositionId = Position.PositionId, MajorId = MajorId });
                }
            }

            Position.AddressId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = pvm.Street, City = pvm.City, PostalCode = pvm.PostalCode, State = pvm.State }, _context);

            // Add additional properties to position
            Position.PositionName = pvm.PositionName;
            Position.PositionDescription = pvm.PositionDescription;
            Position.Deadline = pvm.Deadline;
            Position.PositionType = pvm.PositionType;

            await _context.SaveChangesAsync();

            return RedirectToAction("JobDetails", "Admin", new { Id = Position.PositionId });
        }

        [HttpGet]
        public async Task<IActionResult> CreateApplication(String? Id)
        {
            var Student = await AppUserExtensions.GetStudentById(Id, _context, IncludeDeactivated: false);

            if (Student == null)
            {
                return NotFound();
            }

            var Roles = await _userManager.GetRolesAsync(Student);

            if (Roles.First() != "Student")
            {
                return BadRequest();
            }

            var avm = ApplicationExtensions.CreateApplicationViewModel(Student);

            List<SelectListItem> SelectList = new List<SelectListItem>();

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var Positions = _context.Positions
                .Where(p => p.Deadline <= CurrentUser.SystemDate)
                .Include(p => p.Company)
                .Include(p => p.Address)
                .Include(p => p.PositionMajors)
                .ThenInclude(pm => pm.Major);

            foreach (var Position in Positions)
            {
                SelectListItem sli = new SelectListItem { Text = $"Company: {Position.Company.CompanyName} Name: {Position.PositionName} Deadline: {Position.Deadline.ToString("MMMM dd, yyyy")} Majors: {String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode))}", Value = $"{Position.PositionId}" };
                SelectList.Add(sli);
            }

            ViewBag.SelectList = SelectList;

            return View(avm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationViewModel avm)
        {
            // Get current user and student
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var Student = await AppUserExtensions.GetStudentById(avm.StudentId, _context, IncludeDeactivated: false);

            // Ensure requested user is a student
            var Roles = await _userManager.GetRolesAsync(Student);

            if (Roles.First() != "Student")
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {

                var Positions = _context.Positions
                    .Where(p => p.Deadline <= CurrentUser.SystemDate)
                    .Include(p => p.Company)
                    .Include(p => p.Address)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);

                List<SelectListItem> SelectList = new List<SelectListItem>();

                foreach (var Position in Positions)
                {
                    SelectListItem sli = new SelectListItem { Text = $"Company: {Position.Company.CompanyName} Name: {Position.PositionName} Deadline: {Position.Deadline.ToString("MMMM dd, yyyy")} Majors: {String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode))}", Value = $"{Position.PositionId}" };
                    SelectList.Add(sli);
                }

                ViewBag.SelectList = SelectList;

                return View(avm);
            }

            if (Student == null)
            {
                return BadRequest();
            }

            foreach (var PositionId in avm.Positions)
            {
                var NewApplication = new AppUserPosition { StatusType = StatusType.Accepted, StudentId = avm.StudentId, PositionId = PositionId };

                // check if application already exists and is active
                var PrevApp = await _context.AppUserPositions.FirstOrDefaultAsync(aup => aup.StudentId == Student.Id && aup.PositionId == PositionId && aup.isActive);

                if (PrevApp != null)
                {
                    var Positions = _context.Positions
                        .Where(p => p.Deadline <= CurrentUser.SystemDate)
                        .Include(p => p.Company)
                        .Include(p => p.Address)
                        .Include(p => p.PositionMajors)
                        .ThenInclude(pm => pm.Major);

                    List<SelectListItem> SelectList = new List<SelectListItem>();

                    foreach (var Position in Positions)
                    {
                        SelectListItem sli = new SelectListItem { Text = $"Company: {Position.Company.CompanyName} Name: {Position.PositionName} Deadline: {Position.Deadline.ToString("MMMM dd, yyyy")} Majors: {String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode))}", Value = $"{Position.PositionId}" };
                        SelectList.Add(sli);
                    }

                    ViewBag.SelectList = SelectList;


                    ModelState.AddModelError("", "Student Already Has One or More Active Applications");

                    TempData["StudentId"] = Student.Id;

                    return View(avm);
                }
            }

            List<string> NameList = new List<string>();

            foreach (var PositionId in avm.Positions)
            {
                var NewApplication = new AppUserPosition { StatusType = StatusType.Accepted, StudentId = avm.StudentId, PositionId = PositionId };
                var Pos = await PositionExtensions.GetPositionById(PositionId, _context, IncludeDeativated: false);
                _emailService.SendEmail(new EmailDTO { To = Student.Email, Subject = $"You've been invited to interview for {Pos.PositionName}!", Body = $$"""Hi {{Student.FirstName}},\r\n\r\nCongratulations! You\'ve been invited to interview for the position of {{Pos.PositionName}} with {{Pos.Company.CompanyName}}. We hope you\'re as excited as we are!\r\n\r\nPlease check your email to confirm your interview time.\r\n\r\nIf you have any questions or concerns, please don\'t hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n""" });
                await _context.AddAsync(NewApplication);
                NameList.Add(Pos.PositionName);
            }

            TempData["PositionNames"] = String.Join(", ", NameList);

            await _context.SaveChangesAsync();

            

            return RedirectToAction("StudentDetails", "Admin", new { Id = avm.StudentId });
        }

        [HttpGet]
        public async Task<IActionResult> Interviews()
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var AdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            ViewBag.AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRole.Id).Select(ur => ur.UserId).ToList();

            var Interviews = _context.Interviews
                .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                .Include(i => i.AppUserPosition)
                .ThenInclude(aup => aup.Student)
                .Include(i => i.AppUserPosition)
                .ThenInclude(aup => aup.Position)
                .Include(i => i.Recruiter)
                .ThenInclude(r => r.Company)
                .OrderBy(i => i.InterviewDate);

            ViewBag.Interviews = Interviews;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScheduleMaintenance(InterviewAdminViewModel iavm)
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var AdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            ViewBag.AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRole.Id).Select(ur => ur.UserId).ToList();

            var Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

            ViewBag.Interviews = Interviews;

            if (!ModelState.IsValid)
            {
                return View("Interviews", iavm);
            }

            // Check if there is an overlapping interview
            var OverlappingInterview = await _context.Interviews
                .Where(i => i.Room == iavm.RoomType && ((i.InterviewDate > iavm.InterviewDate && i.InterviewDate < iavm.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > iavm.InterviewDate && i.InterviewDate.AddHours(1) < iavm.InterviewDate.AddHours(1)) || i.InterviewDate == iavm.InterviewDate))
                .FirstOrDefaultAsync();

            if (OverlappingInterview != null)
            {
                ModelState.AddModelError("", "This Timeslot is already reserved");

                return View("Interviews", iavm);
            }

            // Check if hours are within valid range
            if (iavm.InterviewDate < CurrentUser.SystemDate)
            {
                ModelState.AddModelError("", "Timeslot must be greater than or equal to the system date");

                return View("Interviews", iavm);
            }

            if (iavm.InterviewDate.DayOfWeek == DayOfWeek.Saturday || iavm.InterviewDate.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", "Cannot reserve timeslot during the weekend");

                return View("Interviews", iavm);
            }

            if (iavm.InterviewDate.Hour < 8 || iavm.InterviewDate.Hour == 12 || iavm.InterviewDate.Hour >= 17 || (iavm.InterviewDate.Hour == 16 && iavm.InterviewDate.Minute > 0)) // This last condition checks if the interview will go past 5 i.e. scheduled past 4
            {
                if (iavm.InterviewDate.Hour == 12)
                {
                    ModelState.AddModelError("", "Cannot reserve timeslot during lunch break");
                }
                else if (iavm.InterviewDate.Hour >= 17)
                {
                    ModelState.AddModelError("", "Cannot reserve timeslot after working hours");
                }
                else if (iavm.InterviewDate.Hour == 16 && iavm.InterviewDate.Minute > 0)
                {
                    ModelState.AddModelError("", "Interview cannot extend past working hours");
                }
                else // Interview date is before working hours
                {
                    ModelState.AddModelError("", "Cannot reserve timeslot before working hours");
                }

                return View("Interviews", iavm);
            }

            // All checks passed, so book interview
            await _context.AddAsync(new Interview
            {
                RecruiterId = CurrentUser.Id,
                Room = iavm.RoomType,
                InterviewDate = iavm.InterviewDate,
                CreatorId = CurrentUser.Id
            });

            await _context.SaveChangesAsync();

            return View("Interviews", iavm);
        }

        [HttpGet]
        public async Task<IActionResult> CreateInterview(String? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Recruiters", "Admin");
            }

            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var Recruiter = await AppUserExtensions.GetRecruiterById(Id, _context, IncludeDeactivated: false);

            if (Recruiter == null)
            {
                return NotFound();
            }

            var Roles = await _userManager.GetRolesAsync(Recruiter);

            if (Roles.First() != "Recruiter")
            {
                return BadRequest();
            }

            var AdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            ViewBag.AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRole.Id).Select(ur => ur.UserId).ToList();

            var Interviews = _context.Interviews
                .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                .Include(i => i.AppUserPosition)
                .ThenInclude(aup => aup.Student)
                .Include(i => i.AppUserPosition)
                .ThenInclude(aup => aup.Position)
                .Include(i => i.Recruiter)
                .ThenInclude(r => r.Company)
                .OrderBy(i => i.InterviewDate);

            ViewBag.Interviews = Interviews;

            // Create list of comany recruiters
            var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == Recruiter.CompanyId);

            List<SelectListItem> RecruiterList = new List<SelectListItem>();

            foreach (var rec in CompanyRecruiters)
            {
                RecruiterList.Add(new SelectListItem { Text = $"{rec.Company.CompanyName}: {rec.FirstName} {rec.LastName}", Value = rec.Id });
            }

            ViewBag.SelectList = RecruiterList;
            ViewBag.UserId = Id;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterview(InterviewRecruiterViewModel irvm)
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            IOrderedQueryable<Interview> Interviews;

            var Recruiter = await AppUserExtensions.GetRecruiterById(irvm.UserId, _context, IncludeDeactivated: false);
            var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == Recruiter.CompanyId);

            List<SelectListItem> RecruiterList = new List<SelectListItem>();

            foreach (var rec in CompanyRecruiters)
            {
                RecruiterList.Add(new SelectListItem { Text = $"{rec.Company.CompanyName}: {rec.FirstName} {rec.LastName}", Value = rec.Id });
            }

            ViewBag.SelectList = RecruiterList;

            var AdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            ViewBag.AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRole.Id).Select(ur => ur.UserId).ToList();
            ViewBag.UserId = irvm.UserId;

            if (Recruiter == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {

                Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

                ViewBag.Interviews = Interviews;

                return View(irvm);
            }

            var OverlappingInterview = await _context.Interviews
                .Where(i => i.Room == irvm.RoomType && ((i.InterviewDate > irvm.InterviewDate && i.InterviewDate < irvm.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > irvm.InterviewDate && i.InterviewDate.AddHours(1) < irvm.InterviewDate.AddHours(1)) || i.InterviewDate == irvm.InterviewDate))
                .FirstOrDefaultAsync();


            if (OverlappingInterview != null || irvm.InterviewDate < CurrentUser.SystemDate)
            {
                ModelState.AddModelError("", OverlappingInterview != null ? "This Timeslot is already reserved" : "Timeslot must be greater than or equal to the system date");

                ViewBag.SelectList = RecruiterList;

                Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

                ViewBag.Interviews = Interviews;

                return View(irvm);
            }

            var AlreadyScheduledInterview = await _context.Interviews
                .Where(i => i.RecruiterId == irvm.RecruiterId && ((i.InterviewDate > irvm.InterviewDate && i.InterviewDate < irvm.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > irvm.InterviewDate && i.InterviewDate.AddHours(1) < irvm.InterviewDate.AddHours(1)) || i.InterviewDate == irvm.InterviewDate))
                .FirstOrDefaultAsync();

            if (AlreadyScheduledInterview != null)
            {
                ModelState.AddModelError("", "The interviewer is already interviewing at this time");

                Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

                ViewBag.Interviews = Interviews;

                return View(irvm);
            }



            if (irvm.InterviewDate.DayOfWeek == DayOfWeek.Saturday || irvm.InterviewDate.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", "Cannot reserve timeslot during the weekend");

                Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

                ViewBag.Interviews = Interviews;

                return View(irvm);
            }

            if (irvm.InterviewDate.Hour < 8 || irvm.InterviewDate.Hour == 12 || irvm.InterviewDate.Hour >= 17 || (irvm.InterviewDate.Hour == 16 && irvm.InterviewDate.Minute > 0)) // This last condition checks if the interview will go past 5 i.e. scheduled past 4
            {
                if (irvm.InterviewDate.Hour == 12)
                {
                    ModelState.AddModelError("", "Cannot reserve timeslot during lunch break");
                }
                else if (irvm.InterviewDate.Hour >= 17)
                {
                    ModelState.AddModelError("", "Cannot reserve timeslot after working hours");
                }
                else if (irvm.InterviewDate.Hour == 16 && irvm.InterviewDate.Minute > 0)
                {
                    ModelState.AddModelError("", "Interview cannot extend past working hours");
                }
                else // Interview date is before working hours
                {
                    ModelState.AddModelError("", "Cannot reserve timeslot before working hours");
                }

                ViewBag.SelectList = RecruiterList;

                Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

                ViewBag.Interviews = Interviews;

                return View(irvm);
            }

            await _context.AddAsync(new Interview
            {
                RecruiterId = irvm.RecruiterId,
                Room = irvm.RoomType,
                InterviewDate = irvm.InterviewDate,
                CreatorId = CurrentUser.Id
            });

            await _context.SaveChangesAsync();



            Interviews = _context.Interviews
                    .Where(i => i.InterviewDate > CurrentUser.SystemDate)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Student)
                    .Include(i => i.AppUserPosition)
                    .ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company)
                    .OrderBy(i => i.InterviewDate);

            ViewBag.Interviews = Interviews;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ScheduleInterview(AdminStudentViewModel? asvm)
        {
            String StudentId;
            Int32 ApplicationId;

            if (asvm.StudentId == null)
            {
                if (TempData["StudentId"] == null || TempData["ApplicationId"] == null)
                {
                    return BadRequest();
                }
                else
                {
                    StudentId = (String)TempData["StudentId"];
                    ApplicationId = (Int32)TempData["ApplicationId"];
                }
            }
            else
            {
                StudentId = asvm.StudentId;
                ApplicationId = asvm.ApplicationId;
            }

            var App = await ApplicationExtensions.GetApplicationById(_context, ApplicationId, IncludeDeactivated: false);

            if (App.StudentId != StudentId)
            {
                return BadRequest();
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Get interview timeslots from company that they applied for
            var timeslots = _context.Interviews.Where(i => i.AppUserPositionId == null && i.InterviewDate > CurrentUser.SystemDate && i.Recruiter.CompanyId == App.Position.CompanyId)
                .Include(i => i.Recruiter)
                .ThenInclude(r => r.Company);

            List<SelectListItem> SelectList = new List<SelectListItem>();

            foreach (var timeslot in timeslots)
            {
                String FormattedTime = timeslot.InterviewDate.ToString("dddd, dd MMMM yyyy hh:mm tt");
                String FormattedRoom = Utilities.EnumExtensions.GetDisplayName(timeslot.Room);
                SelectListItem sli = new SelectListItem { Text = $"{FormattedTime}, {FormattedRoom}", Value = $"{timeslot.InterviewId}" };
                SelectList.Add(sli);
            }

            ViewBag.UpcomingInterviews = _context.Interviews.Where(i => i.AppUserPosition.StudentId == StudentId && i.InterviewDate > CurrentUser.SystemDate).Include(i => i.AppUserPosition).ThenInclude(aup => aup.Position).Include(i => i.Recruiter).ToList();
            ViewBag.SelectList = SelectList;
            ViewBag.Application = App;

            var interview = await _context.Interviews.FirstOrDefaultAsync(i => i.AppUserPositionId == ApplicationId);

            ViewBag.IsRescheduling = interview != null;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScheduleInterview(InterviewStudentViewModel isvm)
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Declare variable for app
            var App = await ApplicationExtensions.GetApplicationById(_context, isvm.AppUserPositionId, IncludeDeactivated: false);

            if (!ModelState.IsValid)
            {
                TempData["StudentId"] = App.StudentId;
                TempData["ApplicationId"] = isvm.AppUserPositionId;

                // Get interview timeslots from company that they applied for
                var timeslots = CompanyExtensions.GetAvailableTimeslots(_context, CurrentUser.SystemDate, (Int32)App.Position.CompanyId);

                // Create select list with Interview Id as value
                List<SelectListItem> SelectList = new List<SelectListItem>();
                foreach (var timeslot in timeslots)
                {
                    String FormattedTime = timeslot.InterviewDate.ToString("dddd, dd MMMM yyyy hh:mm tt");
                    String FormattedRoom = Utilities.EnumExtensions.GetDisplayName(timeslot.Room);
                    SelectListItem sli = new SelectListItem { Text = $"{FormattedTime}, {FormattedRoom}", Value = $"{timeslot.InterviewId}" };
                    SelectList.Add(sli);
                }

                ViewBag.UpcomingInterviews = InterviewExtensions.GetUpcomingStudentInterviews(_context, CurrentUser);
                ViewBag.SelectList = SelectList;
                ViewBag.Application = App;

                return View(isvm);
            }

            // Check if student is rescheduling interview
            var PrevInterview = await _context.Interviews
                .Where(i => i.AppUserPositionId == isvm.AppUserPositionId && i.AppUserPosition.StudentId == App.StudentId)
                .Include(i => i.AppUserPosition)
                .ThenInclude(i => i.Student)
                .FirstOrDefaultAsync();

            if (PrevInterview != null)
            {
                if ((PrevInterview.InterviewDate - CurrentUser.SystemDate).TotalDays <= 1)
                {
                    TempData["StudentId"] = App.StudentId;
                    TempData["ApplicationId"] = isvm.AppUserPositionId;

                    ModelState.AddModelError("", "You must reschedule more than one day in advance");

                    // Get interview timeslots from company that they applied for
                    var timeslots = _context.Interviews.Where(i => i.AppUserPositionId == null && i.InterviewDate > CurrentUser.SystemDate && i.Recruiter.CompanyId == App.Position.CompanyId)
                        .Include(i => i.Recruiter)
                        .ThenInclude(r => r.Company);

                    List<SelectListItem> SelectList = new List<SelectListItem>();

                    foreach (var timeslot in timeslots)
                    {
                        String FormattedTime = timeslot.InterviewDate.ToString("dddd, dd MMMM yyyy");
                        String FormattedRoom = Utilities.EnumExtensions.GetDisplayName(timeslot.Room);
                        SelectListItem sli = new SelectListItem { Text = $"{FormattedTime}, {FormattedRoom}", Value = $"{timeslot.InterviewId}" };
                        SelectList.Add(sli);
                    }

                    ViewBag.UpcomingInterviews = _context.Interviews.Where(i => i.AppUserPosition.StudentId == App.StudentId && i.InterviewDate > CurrentUser.SystemDate).Include(i => i.AppUserPosition).ThenInclude(aup => aup.Position).Include(i => i.Recruiter).ToList();
                    ViewBag.SelectList = SelectList;
                    ViewBag.Application = App;
                    ViewBag.IsRescheduling = true;

                    return View(isvm);
                }

                ViewBag.IsRescheduling = true;
                PrevInterview.AppUserPositionId = null;
            }

            // If IsRescheduling hasn't been set yet, then it's false
            ViewBag.IsRescheduling ??= false;

            // Grab timeslot associated with request
            var Interview = await _context.Interviews.FirstOrDefaultAsync(i => i.InterviewId == isvm.InterviewId);

            if (Interview == null)
            {
                // If malicious POST request was sent
                return BadRequest();
            }


            var OverlappingInterview = await _context.Interviews
                .Where(i => i.AppUserPosition.StudentId == App.StudentId && ((i.InterviewDate > Interview.InterviewDate && i.InterviewDate < Interview.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > Interview.InterviewDate && i.InterviewDate.AddHours(1) < Interview.InterviewDate.AddHours(1)) ||
                i.InterviewDate == Interview.InterviewDate)).FirstOrDefaultAsync();

            if (OverlappingInterview != null || (Interview.InterviewDate - App.Position.Deadline).TotalHours <= 48)
            {
                TempData["StudentId"] = App.StudentId;
                TempData["ApplicationId"] = isvm.AppUserPositionId;

                String ErrorMsg = OverlappingInterview != null ? "You already have an interview schedule during this timeslot" : "You must interview at least two days after the deadline for your position";

                ModelState.AddModelError("", ErrorMsg);

                // Get interview timeslots from company that they applied for
                var timeslots = _context.Interviews.Where(i => i.AppUserPositionId == null && i.InterviewDate > CurrentUser.SystemDate && i.Recruiter.CompanyId == App.Position.CompanyId)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company);

                List<SelectListItem> SelectList = new List<SelectListItem>();

                foreach (var timeslot in timeslots)
                {
                    String FormattedTime = timeslot.InterviewDate.ToString("dddd, dd MMMM yyyy");
                    String FormattedRoom = Utilities.EnumExtensions.GetDisplayName(timeslot.Room);
                    SelectListItem sli = new SelectListItem { Text = $"{FormattedTime}, {FormattedRoom}", Value = $"{timeslot.InterviewId}" };
                    SelectList.Add(sli);
                }

                ViewBag.UpcomingInterviews = _context.Interviews.Where(i => i.AppUserPosition.StudentId == App.StudentId && i.InterviewDate > CurrentUser.SystemDate).Include(i => i.AppUserPosition).ThenInclude(aup => aup.Position).Include(i => i.Recruiter).ToList();
                ViewBag.SelectList = SelectList;
                ViewBag.Application = App;

                return View(isvm);
            }

            // Relate interview to position
            Interview.AppUserPositionId = isvm.AppUserPositionId;

            // Change new interview slot to student
            Interview.AppUserPositionId = isvm.AppUserPositionId;
            App.InterviewId = Interview.InterviewId;

            if (ViewBag.IsRescheduling)
            {
                TempData["InterviewRescheduledMsg"] = $"Interview Rescheduled for {App.Position.PositionName} at {App.Position.Company.CompanyName}";
            }
            else
            {
                TempData["InterviewScheduledMsg"] = $"Interview Scheduled for {App.Position.PositionName} at {App.Position.Company.CompanyName}";
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("StudentDetails", "Admin", new { Id = App.StudentId });
        }

        [HttpGet]
        public async Task<IActionResult> Admins()
        {
            return View(await AppUserExtensions.GetAllAdmins(_context, IncludeDeactivated: true));
        }

        [HttpGet]
        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(AdminRegisterModel AdminRegisterModel)
        {
            // User did something wrong
            if (!ModelState.IsValid)
            {
                return View(AdminRegisterModel);
            }

            String UserId;
            try
            {
                UserId = await AppUserExtensions.CreateUser(AdminRegisterModel, _userManager, _context);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Account Already Exists");
                return View(AdminRegisterModel);
            }

            _emailService.SendEmail(new EmailDTO { To = AdminRegisterModel.Email, Subject = $"Welcome To Your Candid Account!", Body = $$"""Hi {{AdminRegisterModel.FirstName}},\r\n\r\nWe\'re excited to have you on board with Candid ! With our platform, you can help manage all students and recruiters in the UT community.\r\n\r\nAs a new member, we encourage you to complete your profile as soon as possible to start exploring job postings and connecting with potential employers. If you need any assistance, please feel free to reach out to our support team at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n""" });
            TwilioExtensions.SendMessage($"Hi {AdminRegisterModel.FirstName},\r\n\r\nWe\'re delighted to welcome you to Candid! Your admin account has been created successfully. You can now log in to your account and start managing the site\'s content, users, and settings.\r\n\r\nIf you have any questions or issues, please don\'t hesitate to contact our support team at {System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}. We\'re here to help you get the most out of your Candid admin account.\r\n\r\nThank you for choosing Candid, and we hope you have a great experience!\r\n\r\nBest regards,\r\nThe Candid Team", "");

            return RedirectToAction("AdminDetails", "Admin", new { Id = UserId });
        }

        [HttpGet]
        public async Task<IActionResult> AdminDetails(String? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Admins", "Admin");
            }

            var Admin = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (Admin == null)
            {
                return NotFound();
            }

            // Ensure requested user is an admin
            var Roles = await _userManager.GetRolesAsync(Admin);

            if (Roles.First() != "Admin")
            {
                return BadRequest();
            }


            return View(Admin);
        }

        [HttpGet]
        public async Task<IActionResult> EditAdmin(String? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Admins", "Admin");
            }

            var Admin = await AppUserExtensions.GetAdminById(Id, _context, IncludeDeactivated: true);

            if (Admin == null)
            {
                return NotFound();
            }

            // Ensure requested user in role 
            var Roles = await _userManager.GetRolesAsync(Admin);

            if (Roles.First() != "Admin")
            {
                return NotFound();
            }

            var avm = AppUserExtensions.CreateUserAdminViewModel(Admin);

            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdmin(AdminViewModel avm)
        {
            if (!ModelState.IsValid)
            {
                return View(avm);
            }

            var Admin = await AppUserExtensions.GetAdminById(avm.AdminId, _context, IncludeDeactivated: true);

            if (Admin == null)
            {
                return BadRequest();
            }

            // Ensure requested user is an admin
            var Roles = await _userManager.GetRolesAsync(Admin);

            if (Roles.First() != "Admin")
            {
                return BadRequest();
            }

            Admin.FirstName = avm.FirstName;
            Admin.LastName = avm.LastName;

            await _context.SaveChangesAsync();

            return RedirectToAction("AdminDetails", "Admin", new { Id = Admin.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateAdmin(String? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var Admin = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (Admin == null)
            {
                return BadRequest();
            }

            // Ensure requested user is an admin
            var Roles = await _userManager.GetRolesAsync(Admin);

            if (Roles.First() != "Admin")
            {
                return BadRequest();
            }

            Admin.IsActive = !Admin.IsActive;
            await _context.SaveChangesAsync();

            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            if (Admin.IsActive)
            {
                 _emailService.SendEmail(new EmailDTO { To = Admin.Email, Subject = "Your Candid Admin Account Has Been Reactivated", Body = $$"""Dear {{Admin.FirstName}} {{Admin.LastName}},\r\n\r\nWe are pleased to inform you that your Candid admin account has been reactivated. You can now log in to your account and access all the features and functionalities of our platform. We apologize for any inconvenience caused by the deactivation of your account, and we appreciate your patience and understanding during this time.\r\n\r\nIf you have any questions or concerns about your account reactivation, please don\'t hesitate to contact our support team at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}. We are always happy to help you.\r\n\r\nThank you for using Candid, and we hope you have a great experience on our platform!\r\n\r\nBest regards,\r\nThe Candid Team""" });
            }
            else
            {
                _emailService.SendEmail(new EmailDTO { To = CurrentUser.Email, Subject = $"Account Deactivated: {Admin.FirstName} {Admin.LastName} - {Admin.Email}", Body = $$"""Dear {{CurrentUser.FirstName}} {{CurrentUser.LastName}},\r\n\r\nWe are writing to inform you that the account of an admin on Candid has been deactivated. This may have been due to a violation of our terms of service, a violation of our community guidelines, or inactivity for an extended period.\r\n\r\nWe wanted to inform you of this change and let you know that we have taken the necessary steps to ensure that the admin\'s access to the Candid platform has been revoked.\r\n\r\nIf you have any questions or concerns about this, please do not hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nThank you for your continued support of Candid, and we appreciate your understanding.\r\n\r\nBest regards,\r\n\r\nThe Candid Team""" });
                _emailService.SendEmail(new EmailDTO { To = Admin.Email, Subject = "Notice: Your Candid Account has been Deactivated", Body = $$"""Dear {{Admin.FirstName}} {{Admin.LastName}},\r\n\r\nWe are writing to inform you that your account on Candid has been deactivated. This may be due to a violation of our terms of service, a violation of our community guidelines, or inactivity for an extended period.\r\n\r\nWe understand that this may come as a surprise, and we apologize for any inconvenience this may cause. We encourage you to review our terms of service and community guidelines to ensure that you are aware of our policies and guidelines for using Candid.\r\n\r\nIf you believe that your account has been deactivated in error, or if you have any questions or concerns, please contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nThank you for your contributions to the Candid community, and we wish you all the best in your future endeavors.\r\n\r\nBest regards,\r\n\r\nThe Candid Team""" });
            }

            return RedirectToAction("AdminDetails", "Admin", new { Id = Id });
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            return View(CurrentUser);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var ProfileViewModel = new AdminViewModel
            {
                FirstName = CurrentUser.FirstName,
                LastName = CurrentUser.LastName
            };

            return View(ProfileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(AdminViewModel adminProfileViewModel)
        {
            // Check if profile view model is valid
            if (!ModelState.IsValid)
            {
                return View(adminProfileViewModel);
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Apply changes and save
            CurrentUser.FirstName = adminProfileViewModel.FirstName;
            CurrentUser.LastName = adminProfileViewModel.LastName;

            await _context.SaveChangesAsync();

            // Return redirect to admin profile
            return RedirectToAction("Profile", "Admin");
        }

        // EXTRA FEATURE TWO-FACTOR-AUTHENTICATION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserTFA()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            CurrentUser.TwoFactorEnabled = !CurrentUser.TwoFactorEnabled;

            return RedirectToAction("Profile", "Students");
        }
    }
}