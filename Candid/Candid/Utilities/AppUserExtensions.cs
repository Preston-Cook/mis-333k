using Candid.Models;
using Microsoft.AspNetCore.Identity;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Candid.Utilities
{
    public static class AppUserExtensions
    {
        public async static Task<AppUser> GetCurrentUser(String Email, UserManager<AppUser> userManager)
        {
            return await userManager.FindByEmailAsync(Email);
        }

        public async static Task<String> CreateUser(StudentRegisterModel rvm, UserManager<AppUser> userManager, AppDbContext _context)
        {
            var dbUser = await GetCurrentUser(rvm.Email, userManager);

            // Account already associated with email
            if (dbUser != null)
            {
                throw new Exception("Account Already Exists");
            }

            // Create password hasher and get role for student
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Check if address already exists
            var addrId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = rvm.Street, City = rvm.City, State = rvm.State, PostalCode = rvm.PostalCode }, _context);

            // Add student
            AppUser NewUser = new AppUser
            {
                Gender = rvm.Gender,
                Ethnicity = rvm.Ethnicity,
                AddressId = addrId,
                UserName = rvm.Email,
                Email = rvm.Email,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                GPA = rvm.GPA,
                DateOfBirth = rvm.DateOfBirth,
                GraduationDate = rvm.GraduationDate,
                PositionType = rvm.PositionType
            };

            // Set additional properties
            NewUser.NormalizedUserName = NewUser.UserName.ToUpper();
            NewUser.NormalizedEmail = NewUser.Email.ToUpper();
            NewUser.PasswordHash = passwordHasher.HashPassword(NewUser, rvm.Password);

            // Add user to database and commit
            await _context.AddAsync(NewUser);
            await _context.SaveChangesAsync();

            // Add student's majors
            foreach (var MajorCode in rvm.Majors)
            {
                var Major = await _context.Majors.FirstOrDefaultAsync(m => m.MajorCode == MajorCode);
                await _context.AddAsync(new AppUserMajor { AppUserId = NewUser.Id, MajorId = Major.MajorId });
            }

            // Add user to student role
            await userManager.AddToRoleAsync(NewUser, "Student");

            await _context.SaveChangesAsync();

            return NewUser.Id;
        }

        public async static Task<String> CreateUser(RecruiterRegisterModel rvm, UserManager<AppUser> userManager, AppDbContext _context)
        {
            var dbUser = await GetCurrentUser(rvm.Email, userManager);

            // Account already associated with email
            if (dbUser != null)
            {
                throw new Exception("Account Already Exists");
            }

            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Get Recruiter Company
            var Company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == rvm.CompanyName);

            AppUser NewUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                CompanyId = Company.CompanyId
            };
            // Set additional properties
            NewUser.NormalizedUserName = NewUser.UserName.ToUpper();
            NewUser.NormalizedEmail = NewUser.Email.ToUpper();
            NewUser.PasswordHash = passwordHasher.HashPassword(NewUser, rvm.Password);

            // Add new user to database
            await _context.AddAsync(NewUser);
            await _context.SaveChangesAsync();

            // Add user to recruiter role
            await userManager.AddToRoleAsync(NewUser, "Recruiter");
            await _context.SaveChangesAsync();

            return NewUser.Id;
        }

        public async static Task<String> CreateUser(AdminRegisterModel rvm, UserManager<AppUser> userManager, AppDbContext _context)
        {
            var dbUser = await GetCurrentUser(rvm.Email, userManager);

            // Account already associated with email
            if (dbUser != null)
            {
                throw new Exception("Account Already Exists");
            }

            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Add admin
            AppUser NewUser = new AppUser
            {
                FirstName = rvm.FirstName,
                LastName = rvm.LastName,
                Email = rvm.Email,
                UserName = rvm.Email,
                CompanyId = 14
            };

            // Set additional properties
            NewUser.NormalizedUserName = NewUser.UserName.ToUpper();
            NewUser.NormalizedEmail = NewUser.Email.ToUpper();
            NewUser.PasswordHash = passwordHasher.HashPassword(NewUser, rvm.Password);

            // Add user to database and commit
            await _context.AddAsync(NewUser);
            await _context.SaveChangesAsync();

            // Add user to CSO role and save changes
            await userManager.AddToRoleAsync(NewUser, "Admin");
            await _context.SaveChangesAsync();

            return NewUser.Id;
        }

        public static StudentViewModel CreateUserStudentViewModel(AppUser User)
        {
            List<MajorCodes> MajorCodeList = User.AppUserMajors.Where(aum => aum.isActive).Select(aup => aup.Major.MajorCode).ToList();

            return new StudentViewModel
            {
                StudentId = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Majors = MajorCodeList,
                GraduationDate = (DateTime)User.GraduationDate,
                GPA = User.GPA,
                Ethnicity = User.Ethnicity,
                Gender = User.Gender,
                PositionType = User.PositionType,
                City = User.Address.City,
                Street = User.Address.Street,
                PostalCode = User.Address.PostalCode,
                State = User.Address.State
            };
        }

        public static RecruiterViewModel CreateUserRecruiterViewModel(AppUser Recruiter)
        {
            List<IndustryTypes> Industries = Recruiter.Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => ci.Industry.IndustryType).ToList();

            return new RecruiterViewModel
            {
                RecruiterId = Recruiter.Id,
                FirstName = Recruiter.FirstName,
                LastName = Recruiter.LastName,
                CompanyName = Recruiter.Company.CompanyName,
            };
        }

        public static RecruiterProfileViewModel CreateRecruiterProfileViewModel(AppUser Recruiter)
        {
            var IndustryTypes = Recruiter.Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => ci.Industry.IndustryType).ToList();

            return new RecruiterProfileViewModel
            {
                RecruiterId = Recruiter.Id,
                FirstName = Recruiter.FirstName,
                LastName = Recruiter.LastName,
                CompanyId = Recruiter.Company.CompanyId,
                CompanyName = Recruiter.Company.CompanyName,
                CompanyDescription = Recruiter.Company.CompanyDescription,
                CompanyEmail = Recruiter.Company.CompanyEmail,
                IndustryTypes = IndustryTypes,
                WebsiteUrl = Recruiter.Company.WebsiteUrl,
                City = Recruiter.Company.Address.City,
                Street = Recruiter.Company.Address.Street,
                PostalCode = Recruiter.Company.Address.PostalCode,
                State = Recruiter.Company.Address.State,
                DateCreated = Recruiter.DateCreated

            };
        }

        public static AdminViewModel CreateUserAdminViewModel(AppUser User)
        {
            return new AdminViewModel
            {
                AdminId = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName
            };
        }

        public async static Task<IIncludableQueryable<AppUser, Major>> GetAllStudents(AppDbContext _context, Boolean IncludeDeactivated)
        {
            var StudentRole = await _context.Roles.Where(r => r.Name == "Student").FirstOrDefaultAsync();
            var StudentIds = _context.UserRoles.Where(ur => ur.RoleId == StudentRole.Id).Select(ur => ur.UserId);

            IIncludableQueryable<AppUser, Major> Students;

            if (IncludeDeactivated)
            {
                Students = _context.Users
                    .Where(u => StudentIds.Contains(u.Id))
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }
            else
            {
                Students = _context.Users
                    .Where(u => StudentIds.Contains(u.Id) && u.IsActive)
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }

            return Students;
        }

        public static StudentRegisterModel CreateStudentRegisterModel(AppUser Student)
        {
            var Majors = Student.AppUserMajors.Where(aum => aum.isActive).Select(aum => aum.Major.MajorCode).ToList();

            return new StudentRegisterModel
            {
                UserId = Student.Id,
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                Majors = Majors,
                GPA = Student.GPA,
                DateOfBirth = (DateTime)Student.DateOfBirth,
                GraduationDate = (DateTime)Student.GraduationDate,
                Ethnicity = Student.Ethnicity,
                Gender = Student.Gender,
                PositionType = Student.PositionType,
                Street = Student.Address.Street,
                City = Student.Address.City,
                State = Student.Address.State,
                PostalCode = Student.Address.PostalCode
            };
        }

        public async static Task<IIncludableQueryable<AppUser, Company>> GetAllRecruiters(AppDbContext _context, Boolean IncludeDeactivated)
        {
            var RecruiterRole = await _context.Roles.Where(r => r.Name == "Recruiter").FirstOrDefaultAsync();
            var RecruiterIds = _context.UserRoles.Where(ur => ur.RoleId == RecruiterRole.Id).Select(ur => ur.UserId);

            IIncludableQueryable<AppUser, Company> Recruiters;

            if (IncludeDeactivated)
            {
                Recruiters = _context.Users
                    .Where(u => RecruiterIds.Contains(u.Id))
                    .Include(u => u.Company);
            }
            else
            {
                Recruiters = _context.Users
                    .Where(u => RecruiterIds.Contains(u.Id) && u.IsActive)
                    .Include(u => u.Company);
            }

            return Recruiters;
        }

        public async static Task<IQueryable<AppUser>> GetAllAdmins(AppDbContext _context, Boolean IncludeDeactivated)
        {
            var AdminRole = await _context.Roles.Where(r => r.Name == "Admin").FirstOrDefaultAsync();
            var AdminIds = _context.UserRoles.Where(ur => ur.RoleId == AdminRole.Id).Select(ur => ur.UserId);

            IQueryable<AppUser> Admins;

            if (IncludeDeactivated)
            {
                Admins = _context.Users.Where(u => AdminIds.Contains(u.Id));
            }
            else
            {
                Admins = _context.Users.Where(u => AdminIds.Contains(u.Id) && u.IsActive);
            }

            return Admins;
        }

        public async static Task<AppUser> GetStudentById(String Id, AppDbContext _context, Boolean IncludeDeactivated)
        {
            AppUser Student;

            if (IncludeDeactivated)
            {
                Student = await _context.Users
                    .Where(u => u.Id == Id)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major)
                    .Include(u => u.Address)
                    .FirstOrDefaultAsync();
            }
            else
            {
                Student = await _context.Users
                    .Where(u => u.Id == Id && u.IsActive)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major)
                    .Include(u => u.Address)
                    .FirstOrDefaultAsync();
            }

            return Student;
        }

        public async static Task<AppUser> GetRecruiterById(String Id, AppDbContext _context, Boolean IncludeDeactivated)
        {
            AppUser Recruiter;

            if (IncludeDeactivated)
            {
                Recruiter = await _context.Users.Where(u => u.Id == Id)
                    .Include(u => u.Company)
                    .ThenInclude(c => c.Address)
                    .Include(u => u.Company)
                    .ThenInclude(c => c.CompanyIndustries)
                    .ThenInclude(ci => ci.Industry)
                    .FirstOrDefaultAsync();
            }
            else
            {
                Recruiter = await _context.Users.Where(u => u.Id == Id && u.IsActive)
                    .Include(u => u.Company)
                    .ThenInclude(c => c.Address)
                    .Include(u => u.Company)
                    .ThenInclude(c => c.CompanyIndustries)
                    .ThenInclude(ci => ci.Industry)
                    .FirstOrDefaultAsync();
            }

            return Recruiter;
        }

        public async static Task<AppUser> GetAdminById(String Id, AppDbContext _context, Boolean IncludeDeactivated)
        {
            AppUser Admin;

            if (IncludeDeactivated)
            {
                Admin = await _context.Users.Where(u => u.Id == Id).FirstOrDefaultAsync();
            }
            else
            {
                Admin = await _context.Users.Where(u => u.Id == Id && u.IsActive).FirstOrDefaultAsync();
            }

            return Admin;
        }

        public async static Task<IIncludableQueryable<AppUser, Major>> SearchStudents(StudentSearchViewModel ssvm, AppDbContext _context, Boolean IncludeDeactivated)
        {
            IIncludableQueryable<AppUser, Major> Students = await GetAllStudents(_context, IncludeDeactivated);

            if (ssvm.FirstName != null)
            {
                Students = Students
                    .Where(s => s.FirstName.ToLower().Contains(ssvm.FirstName.ToLower()))
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }

            if (ssvm.LastName != null)
            {
                Students = Students
                    .Where(s => s.LastName.ToLower().Contains(ssvm.LastName.ToLower()))
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }

            if (ssvm.PositionType != null)
            {
                Students = Students
                    .Where(s => s.PositionType == ssvm.PositionType)
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }

            if (ssvm.Majors.Count() >= 1)
            {
                Students = Students
                    .Where(s => s.AppUserMajors.Where(aum => aum.isActive).Select(aum => aum.Major.MajorCode).Any(mc => ssvm.Majors.Contains(mc)))
                    .Include(u => u.Address)
                    .Include(u => u.AppUserMajors)
                    .ThenInclude(u => u.Major);
            }

            if (ssvm.GraduationDate != null)
            {
                if (ssvm.isAboveGraduationDate)
                {
                    Students = Students
                        .Where(s => s.GraduationDate >= ssvm.GraduationDate)
                        .Include(u => u.Address)
                        .Include(u => u.AppUserMajors)
                        .ThenInclude(u => u.Major);
                }
                else
                {
                    Students = Students
                        .Where(s => s.GraduationDate <= ssvm.GraduationDate)
                        .Include(u => u.Address)
                        .Include(u => u.AppUserMajors)
                        .ThenInclude(u => u.Major);
                }
            }

            if (ssvm.GPA != null)
            {
                if (ssvm.isAboveGPA)
                {
                    Students = Students
                        .Where(s => s.GPA >= ssvm.GPA)
                        .Include(u => u.Address)
                        .Include(u => u.AppUserMajors)
                        .ThenInclude(u => u.Major);
                }
                else
                {
                    Students = Students
                        .Where(s => s.GPA <= ssvm.GPA)
                        .Include(u => u.Address)
                        .Include(u => u.AppUserMajors)
                        .ThenInclude(u => u.Major);
                }
            }

            return Students;
        }
    }
}