using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Candid.DAL;
using Candid.Models;
using Candid.Utilities;
using Candid.Services.EmailService;
using Microsoft.EntityFrameworkCore;

namespace Candid.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn, IEmailService emailService)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            _emailService = emailService;
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            // Return registration page to user
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(StudentRegisterModel studentRegisterModel)
        {
            if (!ModelState.IsValid)
            {
                // Redirect user back to page if missing fields
                return View(studentRegisterModel);
            }

            try
            {
                // Try to create user
                await AppUserExtensions.CreateUser(studentRegisterModel, _userManager, _context);
            }
            catch(Exception)
            {
                // Account already exists
                ModelState.AddModelError("", "Account Already Exists");
                return View(studentRegisterModel);
            }

            // Sign in user
            await _signInManager.PasswordSignInAsync(studentRegisterModel.Email, studentRegisterModel.Password, false, lockoutOnFailure: false);

            var ValidatedUser = await _userManager.FindByEmailAsync(studentRegisterModel.Email);

            if (ValidatedUser.LastLoginDate == null)
            {
                TempData["CreationMsg"] = $"Welcome to Candid!\r\n\r\nCongratulations on creating an account with us. We're thrilled to have you on board as a member of our career services community. Here at Candid, we are dedicated to helping you find and apply for your dream job.\r\n\r\nWith your account, you now have access to a wide range of opportunities, including job listings from top recruiters, career resources to enhance your skills, and networking features to connect with professionals in your field. We are committed to providing you with the tools and support you need to succeed in your career journey.\r\n\r\nSo, take a moment to complete your profile, explore the job openings, and make the most out of Candid\'s services. We\'re here to help you every step of the way as you navigate your path to professional success.\r\n\r\nThank you for choosing Candid, and we wish you the best of luck in your job search!\r\n\r\nBest,\r\nThe Candid Team";
            }

            TempData["FirstName"] = ValidatedUser.FirstName;

            ValidatedUser.LastLoginDate = DateTime.Now;
            await _context.SaveChangesAsync();

            _emailService.SendEmail(new EmailDTO { To = ValidatedUser.Email, Subject = "Welcome To Your Candid Account!", Body = $$"""Hi {{ValidatedUser.FirstName}},\r\n\r\nWe\'re excited to have you on board with Candid! Our platform is designed to help students like you find the perfect job or internship opportunity.\r\n\r\nAs a new member, we encourage you to complete your profile as soon as possible to start exploring job postings and connecting with potential employers. If you need any assistance, please feel free to reach out to our support team at {{System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}}.\r\n\r\nBest regards,\r\nCandid Team\r\n"""});
            TwilioExtensions.SendMessage($"Hi {ValidatedUser.FirstName},\r\n\r\nWelcome to Candid! Your account has been created successfully. We\'re excited to help you find job opportunities and kickstart your career. Please log in to your account to get started. If you have any questions or issues, please contact our support team at {System.Environment.GetEnvironmentVariable("CANDID_EMAIL_ADDRESS")}.\r\n\r\nThanks for choosing Candid!\r\n\r\nBest regards,\r\nThe Candid Team", "");

            // Only students ever register themselves, so we can redirect to student dashboard here
            return RedirectToAction("Dashboard", "Student");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(String? returnUrl)
        {
            await _signInManager.SignOutAsync(); 
            ViewBag.ReturnUrl = returnUrl; 
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm)
        {
            // Send user back if fields are null
            if (!ModelState.IsValid)
            {
                return View(lvm);
            }

            // Check if user's account is inactive
            var User = await _context.Users.Where(u => u.Email == lvm.Email).FirstOrDefaultAsync();

            if (User != null && !User.IsActive)
            {
                TempData["DeactivationMsg"] = "Your Account has been Deactivated";
                return Unauthorized();
            }

            // Attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // If user is validated, get their roles and since only one role per user in this app, we can get first role
                var ValidatedUser = await _userManager.FindByEmailAsync(lvm.Email);
                var UserRoles = await _userManager.GetRolesAsync(ValidatedUser);
                var Role = UserRoles.First();

                if (ValidatedUser.LastLoginDate == null)
                {
                    if (Role == "Recruiter")
                    {
                        TempData["CreationMsg"] = $"Welcome to Candid!\r\n\r\nThank you for joining our platform as a recruiter. We\'re excited to have you as part of our community. Candid is committed to connecting you with talented college students who are eager to kickstart their careers.\r\n\r\nWith your recruiter account, you now have access to our database of qualified students, allowing you to search for potential candidates based on various criteria, such as major and GPA. You can also post job openings, manage applications, and edit your company profile seamlessly through our platform.\r\n\r\nWe strive to make your recruiting experience efficient and effective, and our team is here to support you along the way. We\'re dedicated to helping you find the best-fit candidates for your job openings and facilitating meaningful connections between students and recruiters.\r\n\r\nSo, start exploring the talent pool of bright and motivated students, and leverage Candid\'s resources to streamline your recruitment process. Thank you for choosing Candid, and we look forward to partnering with you in finding top talent for your organization.\r\n\r\nBest,\r\nThe Candid Team";
                    }
                    else if (Role == "Admin")
                    {
                        TempData["CreationMsg"] = $"Welcome to Candid!\r\n\r\nAs an admin, you play a crucial role in managing and overseeing our platform. We\'re thrilled to have you join our team, and we look forward to working together to create a seamless experience for our users.\r\n\r\nWith your admin account, you have access to powerful tools and features that allow you to efficiently manage the Candid platform. From user management and data administration to platform customization and performance tracking, you have the ability to ensure smooth operations and a positive experience for all our users.\r\n\r\nAs we continue to grow and evolve, your expertise and contributions will be invaluable in shaping the future of Candid. We\'re committed to providing you with the necessary support and resources to carry out your responsibilities effectively.\r\n\r\nThank you for being an essential part of the Candid team, and we\'re excited to collaborate with you in delivering an exceptional career services experience for our users.\r\n\r\nBest,\r\nThe Candid Team";
                    }
                    else // role is equal to student
                    {
                        TempData["CreationMsg"] = $"Welcome to Candid!\n\nCongratulations on creating an account with us. We\'re thrilled to have you on board as a member of our career services community. Here at Candid, we are dedicated to helping you find and apply for your dream job.\r\n\r\nWith your account, you now have access to a wide range of opportunities, including job listings from top recruiters, career resources to enhance your skills, and networking features to connect with professionals in your field. We are committed to providing you with the tools and support you need to succeed in your career journey.\r\n\r\nSo, take a moment to complete your profile, explore the job openings, and make the most out of Candid\'s services. We\'re here to help you every step of the way as you navigate your path to professional success.\r\n\r\nThank you for choosing Candid, and we wish you the best of luck in your job search!\r\n\r\nBest,\r\nThe Candid Team";
                    }

                    TempData["FirstName"] = ValidatedUser.FirstName;
                }

                // Create log of login
                ValidatedUser.LastLoginDate = DateTime.Now;
                await _context.SaveChangesAsync();

                // Direct user toward respective dashboard
                return RedirectToAction("Dashboard", Role);
            }

            ModelState.AddModelError("", "Invalid login attempt.");
                
            return View(lvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            //sign the user out of the application
            await _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        } 
    }
}