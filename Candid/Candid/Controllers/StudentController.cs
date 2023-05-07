using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Candid.DAL;
using Candid.Models;
using Candid.Utilities;
using Microsoft.EntityFrameworkCore;
using Candid.Services.EmailService;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Candid.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public StudentController(AppDbContext appDbContext, UserManager<AppUser> userManager, IEmailService emailService)
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

            // Store system date in ViewBag
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

            return RedirectToAction("Dashboard", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> Jobs(String? q)
        {

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            IIncludableQueryable<Position, Major> Positions;

            // Get all positions if no search string, otherwise do a basic search
            if (q == null)
            {
                Positions = PositionExtensions.GetAllPositions(_context, PastDate: CurrentUser.SystemDate, IncludeDeativated: false);
            }
            else
            {
                Positions = PositionExtensions.BasicSearchPositions(q, _context, IncludeDeactivated: false, CurrentUser.SystemDate);
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
        public async Task<IActionResult> JobDetails(Int32? Id)
        {

            // If id is null, redirect to page with all positions
            if (Id == null)
            {
                return RedirectToAction("Jobs", "Student");
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Get position by ID that is not deactivated and is not past deadline
            var Pos = await PositionExtensions.GetPositionById((Int32)Id, _context, IncludeDeativated: false, PastDate: CurrentUser.SystemDate);

            // Check if Position Id exists in database within proper contraints
            if (Pos == null)
            {
                return NotFound();
            }

            var Company = await CompanyExtensions.GetCompanyById(_context, (Int32)Pos.CompanyId, IncludeDeactivated: false);

            ViewBag.CompanyIndustries = String.Join(", ", Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => Candid.Utilities.EnumExtensions.GetDisplayName(ci.Industry.IndustryType)));

            // Check if deadline has passed
            ViewBag.DeadlinePassed = Pos.Deadline < CurrentUser.SystemDate;

            // Check if postiion major exists in user's majors
            ViewBag.NotHasMajor = !(await PositionExtensions.PositionContainsStudentMajors(_context, CurrentUser, Pos));

            // Add current uset to viewbag
            ViewBag.HasDifferentType = CurrentUser.PositionType != Pos.PositionType;

            // Check if user has previously applied even if they widthdrew the application
            ViewBag.HasApplied = await PositionExtensions.PositionContainsStudentApplication(_context, CurrentUser, Pos);

            // Return position
            return View(Pos);
        }

        [HttpGet]
        public IActionResult SearchJobs()
        {
            return View("Jobs");
        }

        [HttpGet]
        public async Task<IActionResult> Employers(String? q)
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

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            ViewBag.SystemDate = CurrentUser.SystemDate;

            return View(Companies.OrderBy(c => c.CompanyName));
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

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var Positions = PositionExtensions.SearchPositions(psvm, _context, IncludeDeactivated: false, PastDate: CurrentUser.SystemDate);

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

            return View("Jobs", Positions);
        }

        [HttpGet]
        public IActionResult DetailedEmployerSearch()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailedEmployerSearch(CompanySearchViewModel csvm)
        {
            if (!ModelState.IsValid)
            {
                return View(csvm);
            }

            var Companies = CompanyExtensions.SearchCompanies(csvm, _context, IncludeDeativated: false);

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            ViewBag.SystemDate = CurrentUser.SystemDate;

            return View("Employers", Companies);
        }

        [HttpGet]
        public async Task<IActionResult> EmployerDetails(Int32? Id)
        {
            // If id is null, redirect to page with all employers
            if (Id == null)
            {
                return RedirectToAction("Employers", "Student");
            }

            // Query for company by ID and include relevant navigational properties
            var Company = await CompanyExtensions.GetCompanyById(_context, (Int32)Id, IncludeDeactivated: false);

            // Check if Position Id exists in database
            if (Company == null)
            {
                return NotFound();
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            ViewBag.SystemDate = CurrentUser.SystemDate;

            return View(Company);
        }

        [HttpGet]
        public IActionResult SearchEmployers()
        {
            return View("Employers");
        }

        [HttpGet]
        public async Task<IActionResult> Applications()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            var Applications = ApplicationExtensions.GetAllStudentApplications(_context, CurrentUser, IncludeDeactivated: false);

            // Check if interview has been confirmed and if user has one planned
            ViewBag.SystemDate = CurrentUser.SystemDate;

            return View(Applications);
        }

        [HttpGet]
        public async Task<IActionResult> ScheduleInterview(Int32? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Applications", "Student");
            }

            // Retrieve application from database
            var App = await ApplicationExtensions.GetApplicationById(_context, (Int32)Id, IncludeDeactivated: false);

            if (App == null)
            {
                return NotFound();
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

            ViewBag.UpcomingInterviews = InterviewExtensions.GetUpcomingStudentInterviews(_context, CurrentUser);
            ViewBag.SelectList = SelectList;
            ViewBag.Application = App;

            var interview = await _context.Interviews.FirstOrDefaultAsync(i => i.AppUserPositionId == Id);

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
                .Where(i => i.AppUserPositionId == isvm.AppUserPositionId && i.AppUserPosition.StudentId == CurrentUser.Id)
                .Include(i => i.AppUserPosition)
                .ThenInclude(i => i.Student)
                .FirstOrDefaultAsync();

            if (PrevInterview != null)
            {
                if ((PrevInterview.InterviewDate - CurrentUser.SystemDate).TotalDays <= 1)
                {
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

                    ViewBag.UpcomingInterviews = InterviewExtensions.GetUpcomingStudentInterviews(_context, CurrentUser);
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
                .Where(i => i.AppUserPosition.StudentId == CurrentUser.Id && ((i.InterviewDate > Interview.InterviewDate && i.InterviewDate < Interview.InterviewDate.AddHours(1)) ||
                (i.InterviewDate.AddHours(1) > Interview.InterviewDate && i.InterviewDate.AddHours(1) < Interview.InterviewDate.AddHours(1)) ||
                i.InterviewDate == Interview.InterviewDate)).FirstOrDefaultAsync();

            if (OverlappingInterview != null || (Interview.InterviewDate - App.Position.Deadline).TotalHours <= 48)
            {
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

                ViewBag.UpcomingInterviews = InterviewExtensions.GetUpcomingStudentInterviews(_context, CurrentUser);
                ViewBag.SelectList = SelectList;
                ViewBag.Application = App;

                return View(isvm);
            }

            // Relate interview to position
            Interview.AppUserPositionId = isvm.AppUserPositionId;

            // Change new interview slot to student
            Interview.AppUserPositionId = isvm.AppUserPositionId;
            App.InterviewId = Interview.InterviewId;

            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Student");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApplication(Int32? PositionId)
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            if (PositionId == null)
            {
                // If post request is missing parameter
                return BadRequest();
            }

            // Check if currently open position exists at requested ID
            var Pos = await PositionExtensions.GetPositionById((Int32)PositionId, _context, IncludeDeativated: false, PastDate: CurrentUser.SystemDate);

            if (Pos == null)
            {
                return BadRequest();
            }

            // Check if the position type matches the student's position type
            if (Pos.PositionType != CurrentUser.PositionType)
            {
                return BadRequest();
            }

            // Check if user major is inside the position's majors
            Boolean HasMatch = await PositionExtensions.PositionContainsStudentMajors(_context, CurrentUser, Pos);

            if (!HasMatch)
            {
                return BadRequest();
            }

            // Check if student has already applied for position already
            Boolean HasApplied = await PositionExtensions.PositionContainsStudentApplication(_context, CurrentUser, Pos);

            if (HasApplied)
            {
                return BadRequest();
            }

            // Create application and add to database
            await ApplicationExtensions.CreateApplication(_context, CurrentUser, Pos);

            _emailService.SendEmail(new EmailDTO { To = CurrentUser.Email, Subject = $"Your application for {Pos.PositionName} has been received!", Body = $$"""Hi {{CurrentUser.FirstName}},\r\n\r\nThank you for applying for {{Pos.PositionName}} on Candid Careers! Your application has been received and is being reviewed by the employer.\r\n\r\nIf the employer is interested in your application, they will reach out to you directly to schedule an interview. In the meantime, feel free to keep exploring other job opportunities on our platform.\r\n\r\nIf you have any questions about your application or the application process, please reach out to us at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Careers Team\r\n""" });

            TempData["AddedMsg"] = $"Your application for {Pos.PositionName} at {Pos.Company.CompanyName} has been received!";

            return RedirectToAction("Applications", "Student");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WithdrawApplication(Int32? ApplicationId)
        {
            // Ensure Application ID was provided in POST request
            if (ApplicationId == null)
            {
                return BadRequest();
            }

            // Find application in database
            var Application = await ApplicationExtensions.GetApplicationById(_context, (Int32)ApplicationId, IncludeDeactivated: false);

            // Check if application exists in database
            if (Application == null)
            {
                return BadRequest();
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Ensure the current user is the applicant
            if (Application.StudentId != CurrentUser.Id)
            {
                return Unauthorized();
            }

            // Ensure deadline has not passed
            if (Application.Position.Deadline <= CurrentUser.SystemDate)
            {
                TempData["ErrorMsg"] = "The deadline for the application has passed. You cannot withdraw it";
                return RedirectToAction("Applications", "Student");
            }

            // Withdraw application
            Application.isActive = false;
            await _context.SaveChangesAsync();

            var Company = await CompanyExtensions.GetCompanyById(_context, (Int32)Application.Position.CompanyId, IncludeDeactivated: false);

            TempData["DeletedMsg"] = $"Your application for {Application.Position.PositionName} at {Company.CompanyName} has been withdrawn";

            return RedirectToAction("Applications", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Query for user's majors
            var Student = await AppUserExtensions.GetStudentById(CurrentUser.Id, _context, IncludeDeactivated: false);

            return View(CurrentUser);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            // Query for user's majors
            var Student = await AppUserExtensions.GetStudentById(CurrentUser.Id, _context, IncludeDeactivated: false);
            var ProfileViewModel = AppUserExtensions.CreateUserStudentViewModel(Student);

            return View(ProfileViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(StudentViewModel svm)
        {

            // Return model back if it's invalid
            if (!ModelState.IsValid)
            {
                return View(svm);
            }

            // Get current user
            var CurrentUser = await AppUserExtensions.GetCurrentUser(User.Identity.Name, _userManager);

            CurrentUser.FirstName = svm.FirstName;
            CurrentUser.LastName = svm.LastName;

            // Set all user's majors to inactive
            foreach (var aum in _context.AppUserMajors.Where(aum => aum.AppUserId == CurrentUser.Id && aum.isActive))
            {
                aum.isActive = false;
            }

            foreach (var MajorCode in svm.Majors)
            {
                // Get Id for major
                var Major = await _context.Majors.FirstOrDefaultAsync(m => m.MajorCode == MajorCode);
                var MajorId = Major.MajorId;

                // Check if user already has major
                var UserMajor = await _context.AppUserMajors.FirstOrDefaultAsync(aum => aum.AppUserId == CurrentUser.Id && aum.MajorId == MajorId);

                // If user already has an entry for the major, set it active. Otherwise add
                if (UserMajor != null)
                {
                    UserMajor.isActive = true;
                }
                else
                {
                    await _context.AppUserMajors.AddAsync(new AppUserMajor { AppUserId = CurrentUser.Id, MajorId = MajorId });
                }
            }

            // Set fields for current user
            CurrentUser.GraduationDate = svm.GraduationDate;
            CurrentUser.GPA = svm.GPA;
            CurrentUser.Ethnicity = svm.Ethnicity;
            CurrentUser.Gender = svm.Gender;
            CurrentUser.PositionType = svm.PositionType;

            // Call utility method to get Address Id
            CurrentUser.AddressId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = svm.Street, City = svm.City, PostalCode = svm.PostalCode, State = svm.State }, _context);

            // Save changes to database
            await _context.SaveChangesAsync();

            // Redirect user to profile page
            return RedirectToAction("Profile", "Student");
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