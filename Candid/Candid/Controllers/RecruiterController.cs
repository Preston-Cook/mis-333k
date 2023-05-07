using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Candid.DAL;
using Candid.Models;
using Candid.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candid.Services.EmailService;

namespace Candid.Controllers
{
    [Authorize(Roles = "Recruiter")]
    public class RecruiterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        private readonly IEmailService _emailService;

        public RecruiterController(AppDbContext db, UserManager<AppUser> userManager, IEmailService emailService)
        {
            _context = db;
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            // Get current user
            var UserEmail = User.Identity.Name;
            var CurrentUser = await _userManager.FindByEmailAsync(UserEmail);
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

            return RedirectToAction("Dashboard", "Recruiter");
        }

        [HttpGet]
        public async Task<IActionResult> Candidates()
        {
            // Get Current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);


            var ClosedApplications = _context.AppUserPositions
                .Where(aup => aup.isActive && aup.Position.Deadline < CurrentUser.SystemDate && aup.Position.CompanyId == CurrentUser.CompanyId && aup.Student.IsActive)
                .Include(aup => aup.Position)
                .ThenInclude(p => p.Company)
                .Include(aup => aup.Student);


            return View(ClosedApplications);
        }

        [HttpGet]
        public async Task<IActionResult> CandidateDetails(Int32? Id)
        {
            {
                if (Id == null)
                {
                    return RedirectToAction("Candidates", "Recruiter");
                }

                var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

                var App = _context.AppUserPositions.Where(aup => aup.isActive && aup.Position.Deadline < CurrentUser.SystemDate && aup.Position.CompanyId == CurrentUser.CompanyId && aup.AppUserPositionId == Id)
                    .Include(a => a.Student)
                    .Include(a => a.Position)
                    .ThenInclude(p => p.Address)
                    .FirstOrDefault();

                if (App == null)
                {
                    return NotFound();
                }

                // Get student's majors
                var Student = await AppUserExtensions.GetStudentById(App.StudentId, _context, IncludeDeactivated: false);

                ViewBag.StudentMajors = String.Join(", ", Student.AppUserMajors.Where(aum => aum.isActive).Select(aum => aum.Major.MajorName));

                // Get Position's Majors
                var Position = await PositionExtensions.GetPositionById(App.PositionId, _context, IncludeDeativated: false);
                ViewBag.PositionMajors = String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorName));

                return View(App);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Jobs()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var Positions = _context.Positions
                .Where(p => p.CompanyId == CurrentUser.CompanyId)
                .Include(p => p.Company)
                .Include(p => p.Address)
                .Include(p => p.PositionMajors)
                .ThenInclude(pm => pm.Major);

            return View(Positions);
        }

        [HttpGet]
        public async Task<IActionResult> JobDetails(Int32? Id)
        {

            // If id is null, redirect to page with all positions
            if (Id == null)
            {
                return RedirectToAction("Jobs", "Recruiter");
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
                return RedirectToAction("Jobs", "Recruiter");
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

            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var SameName = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName.ToLower() == pvm.PositionName.ToLower() && p.CompanyId == CurrentUser.CompanyId && p.PositionId != pvm.PositionId);

            if (SameName != null)
            {
                ModelState.AddModelError("", "Position with this Name Already Exists");
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

            return RedirectToAction("JobDetails", "Recruiter", new { Id = Position.PositionId });
        }

        [HttpGet]
        public IActionResult CreateJob()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJob(PositionViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                return View(pvm);
            }

            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var Recruiter = await AppUserExtensions.GetRecruiterById(CurrentUser.Id, _context, IncludeDeactivated: false);

            pvm.CompanyId = (Int32)Recruiter.CompanyId;

            if (pvm.Deadline < CurrentUser.SystemDate)
            {
                ModelState.AddModelError("", "Deadline Already Passed");
                return View(pvm);
            }

            try
            {
                await PositionExtensions.CreatePosition(pvm, _context);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Position already exists");
                return View(pvm);
            }

            return RedirectToAction("Jobs", "Recruiter");
        }

        [HttpGet]
        public async Task<IActionResult> Students(String? q)
        {
            IIncludableQueryable<AppUser, Major> Students = await AppUserExtensions.GetAllStudents(_context, IncludeDeactivated: false);

            if (q != null)
            {
                Students = Students.Where(s => s.IsActive && (s.FirstName.ToLower().Contains(q.ToLower()) || s.LastName.ToLower().Contains(q.ToLower())))
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

            var Students = await AppUserExtensions.SearchStudents(ssvm, _context, IncludeDeactivated: false);

            return View("Students", Students);
        }

        [HttpGet]
        public async Task<IActionResult> StudentDetails(String? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Students", "Recruiter");
            }

            var Student = await AppUserExtensions.GetStudentById(Id, _context, IncludeDeactivated: false);

            if (Student == null)
            {
                return NotFound();
            }

            // Ensure requested user is in student role
            var Roles = await _userManager.GetRolesAsync(Student);

            if (Roles.First() != "Student")
            {
                return BadRequest();
            }

            var svm = AppUserExtensions.CreateUserStudentViewModel(Student);

            return View(svm);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var Recruiter = await AppUserExtensions.GetRecruiterById(CurrentUser.Id, _context, IncludeDeactivated: false);
            var rvm = AppUserExtensions.CreateRecruiterProfileViewModel(Recruiter);

            return View(rvm);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var Recruiter = await AppUserExtensions.GetRecruiterById(CurrentUser.Id, _context, IncludeDeactivated: false);
            var rvm = AppUserExtensions.CreateRecruiterProfileViewModel(Recruiter);

            return View(rvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(RecruiterProfileViewModel rvm)
        {
            if (!ModelState.IsValid)
            {
                return View(rvm);
            }

            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var Recruiter = await AppUserExtensions.GetRecruiterById(CurrentUser.Id, _context, IncludeDeactivated: false);

            var SameName = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName.ToLower() == rvm.CompanyName.ToLower() && c.CompanyId != Recruiter.CompanyId);

            if (SameName != null)
            {
                ModelState.AddModelError("", "Another Company of this Name Already Exists");
                return View(rvm);
            }

            Recruiter.FirstName = rvm.FirstName;
            Recruiter.LastName = rvm.LastName;
            Recruiter.Company.CompanyName = rvm.CompanyName;
            Recruiter.Company.CompanyDescription = rvm.CompanyDescription;
            Recruiter.Company.WebsiteUrl = rvm.WebsiteUrl;
            Recruiter.Company.CompanyEmail = rvm.CompanyEmail;

            await _context.SaveChangesAsync();

            foreach (var CompanyIndustry in _context.CompanyIndustries.Where(ci => ci.CompanyId == Recruiter.Company.CompanyId))
            {
                CompanyIndustry.isActive = false;
            }

            foreach (var IndustryType in rvm.IndustryTypes)
            {
                // Get Id for industry type
                var Industry = await _context.Industries.Where(i => i.IndustryType == IndustryType).FirstOrDefaultAsync();
                var IndustryId = Industry.IndustryId;

                // Check if company already has industry
                var CompanyIndustry = await _context.CompanyIndustries.Where(ci => ci.IndustryId == IndustryId && ci.CompanyId == Recruiter.Company.CompanyId).FirstOrDefaultAsync();

                if (CompanyIndustry != null)
                {
                    CompanyIndustry.isActive = true;
                }
                else
                {
                    await _context.CompanyIndustries.AddAsync(new CompanyIndustry { CompanyId = Recruiter.Company.CompanyId, IndustryId = IndustryId });
                }
            }

            Recruiter.Company.AddressId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = rvm.Street, City = rvm.City, PostalCode = rvm.PostalCode, State = rvm.State }, _context);

            // Save changes to database
            await _context.SaveChangesAsync();

            // Redirect user to profile page
            return RedirectToAction("Profile", "Recruiter");
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
                .Where(p => p.CompanyId == CurrentUser.CompanyId && p.Deadline <= CurrentUser.SystemDate)
                .Include(p => p.Company)
                .Include(p => p.Address)
                .Include(p => p.PositionMajors)
                .ThenInclude(pm => pm.Major);

            foreach (var Position in Positions)
            {
                SelectListItem sli = new SelectListItem { Text = $"Name: {Position.PositionName} Deadline: {Position.Deadline.ToString("MMMM dd, yyyy")} Majors: {String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode))}", Value = $"{Position.PositionId}" };
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
                    .Where(p => p.CompanyId == CurrentUser.CompanyId && p.Deadline <= CurrentUser.SystemDate)
                    .Include(p => p.Company)
                    .Include(p => p.Address)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);

                List<SelectListItem> SelectList = new List<SelectListItem>();

                foreach (var Position in Positions)
                {
                    SelectListItem sli = new SelectListItem { Text = $"Name: {Position.PositionName} Deadline: {Position.Deadline.ToString("MMMM dd, yyyy")} Majors: {String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode))}", Value = $"{Position.PositionId}" };
                    SelectList.Add(sli);
                }

                return View(avm);
            }

            if (Student == null)
            {
                return BadRequest();
            }

            foreach (var PositionId in avm.Positions)
            {

                // check if application already exists and is active
                var PrevApp = await _context.AppUserPositions.FirstOrDefaultAsync(aup => aup.StudentId == Student.Id && aup.PositionId == PositionId && aup.isActive);

                if (PrevApp != null)
                {
                    var Positions = _context.Positions
                        .Where(p => p.CompanyId == CurrentUser.CompanyId && p.Deadline <= CurrentUser.SystemDate)
                        .Include(p => p.Company)
                        .Include(p => p.Address)
                        .Include(p => p.PositionMajors)
                        .ThenInclude(pm => pm.Major);

                    List<SelectListItem> SelectList = new List<SelectListItem>();

                    foreach (var Position in Positions)
                    {
                        SelectListItem sli = new SelectListItem { Text = $"Name: {Position.PositionName} Deadline: {Position.Deadline.ToString("MMMM dd, yyyy")} Majors: {String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode))}", Value = $"{Position.PositionId}" };
                        SelectList.Add(sli);
                    }

                    ViewBag.SelectList = SelectList;

                    ModelState.AddModelError("", "Student Already Has One or More Active Applications");

                    return View(avm);
                }
            }

            foreach (var PositionId in avm.Positions)
            {
                var NewApplication = new AppUserPosition { StatusType = StatusType.Accepted, StudentId = avm.StudentId, PositionId = PositionId };
                var Pos = await PositionExtensions.GetPositionById(PositionId, _context, IncludeDeativated: false);
                _emailService.SendEmail(new EmailDTO { To = Student.Email, Subject = $"You've been invited to interview for {Pos.PositionName}!", Body = $$"""Hi {{Student.FirstName}},\r\n\r\nCongratulations! You\'ve been invited to interview for the position of {{Pos.PositionName}} with {{Pos.Company.CompanyName}}. We hope you\'re as excited as we are!\r\n\r\nPlease check your email to confirm your interview time.\r\n\r\nIf you have any questions or concerns, please don\'t hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n""" });
                await _context.AddAsync(NewApplication);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Candidates", "Recruiter");
        }

        [HttpPost]
        public async Task<IActionResult> AcceptApplication(Int32? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var App = await ApplicationExtensions.GetApplicationById(_context, (Int32)Id, IncludeDeactivated: false);

            if (App == null)
            {
                return BadRequest();
            }

            App.StatusType = StatusType.Accepted;


            _emailService.SendEmail(new EmailDTO { To = App.Student.Email, Subject = $"Your application status for {App.Position.PositionName} has changed!", Body = $$"""Hi {{App.Student.FirstName}},\r\n\r\nYour application status for {{App.Position.PositionName}} has changed! Please continue to check your status to stay up to date with your application.\r\n\r\nIf you have any questions about your application or the application process, please reach out to us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n""" });
            TwilioExtensions.SendMessage($"Hi {App.Student.FirstName},\r\n\r\nWe wanted to inform you that the status of your application for the {App.Position.PositionName} job has been updated. Please log in to your Candid account to see the changes. If you have any questions or concerns about the application status or the next steps, please contact our support team at {System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}.\r\n\r\nThank you for using Candid, and we wish you the best of luck with your job search!\r\n\r\nBest regards,\r\nThe Candid Team", "");
            _emailService.SendEmail(new EmailDTO { To = App.Student.Email, Subject = $"You've been invited to interview for {App.Position.PositionName}!", Body = $$"""Hi {{App.Student.FirstName}},\r\n\r\nCongratulations! You\'ve been invited to interview for the position of {{App.Position.PositionName}} with {{App.Position.Company.CompanyName}}. We hope you\'re as excited as we are!\r\n\r\nPlease check your email to confirm your interview time.\r\n\r\nIf you have any questions or concerns, please don\'t hesitate to contact us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n""" });

            await _context.SaveChangesAsync();

            // Get student's majors
            var Student = await AppUserExtensions.GetStudentById(App.StudentId, _context, IncludeDeactivated: false);

            ViewBag.StudentMajors = String.Join(", ", Student.AppUserMajors.Where(aum => aum.isActive).Select(aum => aum.Major.MajorName));

            // Get Position's Majors
            var Position = await PositionExtensions.GetPositionById(App.PositionId, _context, IncludeDeativated: false);
            ViewBag.PositionMajors = String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorName));

            return View("CandidateDetails", App);
        }

        [HttpPost]
        public async Task<IActionResult> DenyApplication(Int32? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var App = await ApplicationExtensions.GetApplicationById(_context, (Int32)Id, IncludeDeactivated: false);

            if (App == null)
            {
                return BadRequest();
            }

            App.StatusType = StatusType.Denied;

            await _context.SaveChangesAsync();

            _emailService.SendEmail(new EmailDTO { To = App.Student.Email, Subject = $"Your application status for {App.Position.PositionName} has changed!", Body = $$"""Hi {{App.Student.FirstName}},\r\n\r\nYour application status for {{App.Position.PositionName}} has changed! Please continue to check your status to stay up to date with your application.\r\n\r\nIf you have any questions about your application or the application process, please reach out to us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid  Team\r\n""" });
            TwilioExtensions.SendMessage($"Hi {App.Student.FirstName},\r\n\r\nWe wanted to inform you that the status of your application for the {App.Position.PositionName} job has been updated. Please log in to your Candid account to see the changes. If you have any questions or concerns about the application status or the next steps, please contact our support team at {System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}.\r\n\r\nThank you for using Candid, and we wish you the best of luck with your job search!\r\n\r\nBest regards,\r\nThe Candid Team", "");

            // Get student's majors
            var Student = await AppUserExtensions.GetStudentById(App.StudentId, _context, IncludeDeactivated: false);

            ViewBag.StudentMajors = String.Join(", ", Student.AppUserMajors.Where(aum => aum.isActive).Select(aum => aum.Major.MajorName));

            // Get Position's Majors
            var Position = await PositionExtensions.GetPositionById(App.PositionId, _context, IncludeDeativated: false);
            ViewBag.PositionMajors = String.Join(", ", Position.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorName));

            return View("CandidateDetails", App);
        }

        [HttpGet]
        public async Task<IActionResult> Interviews()
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);
            var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == CurrentUser.CompanyId);

            List<SelectListItem> RecruiterList = new List<SelectListItem>();

            foreach (var rec in CompanyRecruiters)
            {
                RecruiterList.Add(new SelectListItem { Text = $"{rec.FirstName} {rec.LastName}", Value = rec.Id });
            }

            var AdminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            ViewBag.AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRole.Id).Select(ur => ur.UserId).ToList();
            ViewBag.CompanyId = CurrentUser.CompanyId;
            ViewBag.CompanyRecruiters = RecruiterList;

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
        public async Task<IActionResult> CreateInterview(InterviewRecruiterViewModel irvm)
        {
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var AdminRoleId = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            ViewBag.AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRoleId.Id).Select(ur => ur.UserId).ToList();

            if (!ModelState.IsValid)
            {
                var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == CurrentUser.CompanyId);

                List<SelectListItem> RecruiterList = new List<SelectListItem>();

                foreach (var rec in CompanyRecruiters)
                {
                    RecruiterList.Add(new SelectListItem { Text = $"{rec.FirstName} {rec.LastName}", Value = rec.Id });
                }

                ViewBag.CompanyId = CurrentUser.CompanyId;
                ViewBag.CompanyRecruiters = RecruiterList;

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

                return View("Interviews", irvm);
            }

            var OverlappingInterview = await _context.Interviews
                .Where(i => i.Room == irvm.RoomType && ((i.InterviewDate > irvm.InterviewDate && i.InterviewDate < irvm.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > irvm.InterviewDate && i.InterviewDate.AddHours(1) < irvm.InterviewDate.AddHours(1)) || i.InterviewDate == irvm.InterviewDate))
                .FirstOrDefaultAsync();


            if (OverlappingInterview != null || irvm.InterviewDate < CurrentUser.SystemDate)
            {
                ModelState.AddModelError("", OverlappingInterview != null ? "This Timeslot is already reserved" : "Timeslot must be greater than or equal to the system date");
                var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == CurrentUser.CompanyId);

                List<SelectListItem> RecruiterList = new List<SelectListItem>();

                foreach (var rec in CompanyRecruiters)
                {
                    RecruiterList.Add(new SelectListItem { Text = $"{rec.FirstName} {rec.LastName}", Value = rec.Id });
                }

                ViewBag.CompanyId = CurrentUser.CompanyId;
                ViewBag.CompanyRecruiters = RecruiterList;

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

                return View("Interviews", irvm);
            }

            var AlreadyScheduledInterview = await _context.Interviews
                .Where(i => i.RecruiterId == irvm.RecruiterId && ((i.InterviewDate > irvm.InterviewDate && i.InterviewDate < irvm.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > irvm.InterviewDate && i.InterviewDate.AddHours(1) < irvm.InterviewDate.AddHours(1)) || i.InterviewDate == irvm.InterviewDate))
                .FirstOrDefaultAsync();

            if (AlreadyScheduledInterview != null)
            {
                ModelState.AddModelError("", "The interviewer is already interviewing at this time");

                var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == CurrentUser.CompanyId);

                List<SelectListItem> RecruiterList = new List<SelectListItem>();

                foreach (var rec in CompanyRecruiters)
                {
                    RecruiterList.Add(new SelectListItem { Text = $"{rec.FirstName} {rec.LastName}", Value = rec.Id });
                }

                ViewBag.CompanyId = CurrentUser.CompanyId;
                ViewBag.CompanyRecruiters = RecruiterList;

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

                return View("Interviews", irvm);
            }



            if (irvm.InterviewDate.DayOfWeek == DayOfWeek.Saturday || irvm.InterviewDate.DayOfWeek == DayOfWeek.Sunday)
            {
                ModelState.AddModelError("", "Cannot reserve timeslot during the weekend");

                var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == CurrentUser.CompanyId);

                List<SelectListItem> RecruiterList = new List<SelectListItem>();

                foreach (var rec in CompanyRecruiters)
                {
                    RecruiterList.Add(new SelectListItem { Text = $"{rec.FirstName} {rec.LastName}", Value = rec.Id });
                }

                ViewBag.CompanyId = CurrentUser.CompanyId;
                ViewBag.CompanyRecruiters = RecruiterList;

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

                return View("Interviews", irvm);
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

                var CompanyRecruiters = _context.Users.Where(u => u.IsActive && u.Company.CompanyId == CurrentUser.CompanyId);

                List<SelectListItem> RecruiterList = new List<SelectListItem>();

                foreach (var rec in CompanyRecruiters)
                {
                    RecruiterList.Add(new SelectListItem { Text = $"{rec.FirstName} {rec.LastName}", Value = rec.Id });
                }

                ViewBag.CompanyId = CurrentUser.CompanyId;
                ViewBag.CompanyRecruiters = RecruiterList;

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

                return View("Interviews", irvm);
            }

            await _context.AddAsync(new Interview
            {
                RecruiterId = irvm.RecruiterId,
                Room = irvm.RoomType,
                InterviewDate = irvm.InterviewDate,
                CreatorId = CurrentUser.Id
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Interviews", "Recruiter");
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