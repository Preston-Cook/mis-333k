using Candid.Models;
using Microsoft.AspNetCore.Identity;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Candid.Utilities
{
    public static class ApplicationExtensions
    {
        public static IIncludableQueryable<AppUserPosition, Interview> GetAllApplications(AppDbContext _context, Boolean IncludeDeactivated)
        {
            IIncludableQueryable<AppUserPosition, Interview> Applications;
            
            if (IncludeDeactivated)
            {
                Applications = _context.AppUserPositions
                    .Include(aup => aup.Student)
                    .Include(aup => aup.Position)
                    .ThenInclude(aup => aup.Company)
                    .Include(aup => aup.Interview);
            }
            else
            {
                Applications = _context.AppUserPositions
                    .Where(aup => aup.isActive)
                    .Include(aup => aup.Student)
                    .Include(aup => aup.Position)
                    .ThenInclude(aup => aup.Company)
                    .Include(aup => aup.Interview);;
            }

            return Applications;
        }

        public static IIncludableQueryable<AppUserPosition, Interview> GetAllStudentApplications(AppDbContext _context, AppUser Student, Boolean IncludeDeactivated)
        {   
            IIncludableQueryable<AppUserPosition, Interview> Applications;

            if (IncludeDeactivated)
            {
                Applications = _context.AppUserPositions
                    .Where(aup => aup.StudentId == Student.Id)
                    .Include(aup => aup.Position)
                    .ThenInclude(aup => aup.Company)
                    .Include(aup => aup.Interview);
            }
            else
            {
                Applications = _context.AppUserPositions
                    .Where(aup => aup.StudentId == Student.Id && aup.isActive)
                    .Include(aup => aup.Position)
                    .ThenInclude(aup => aup.Company)
                    .Include(aup => aup.Interview);
            }

            return Applications;

        }

        public async static Task<AppUserPosition> GetApplicationById(AppDbContext _context, Int32 ApplicationId, Boolean IncludeDeactivated)
        {
            AppUserPosition Application;

            if (IncludeDeactivated)
            {
                Application = await _context.AppUserPositions
                    .Where(aup => aup.AppUserPositionId == ApplicationId)
                    .Include(aup => aup.Student)
                    .Include(aup => aup.Position)
                    .ThenInclude(aup => aup.Company)
                    .FirstOrDefaultAsync();
            }
            else
            {
                Application = await _context.AppUserPositions
                    .Where(aup => aup.AppUserPositionId == ApplicationId && aup.isActive)
                    .Include(aup => aup.Student)
                    .Include(aup => aup.Position)
                    .ThenInclude(aup => aup.Company)
                    .FirstOrDefaultAsync();
            }

            return Application;
        }

        public async static Task CreateApplication(AppDbContext _context, AppUser Student, Position Position)
        {
            var NewApp = new AppUserPosition
            {
                PositionId = (Int32)Position.PositionId,
                StudentId = Student.Id
            };

            _context.Add(NewApp);
            await _context.SaveChangesAsync();
        }

        public static ApplicationViewModel CreateApplicationViewModel(AppUser User)
        {
            String FormattedMajors = String.Join(", ", User.AppUserMajors.Where(aum => aum.isActive).Select(aum => aum.Major.MajorName));

            return new ApplicationViewModel
            {
                StudentId = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                GraduationDate = (DateTime)User.GraduationDate,
                Gender = User.Gender,
                Ethnicity = User.Ethnicity,
                Majors = FormattedMajors,
                GPA = User.GPA
            };
        }
    }
}