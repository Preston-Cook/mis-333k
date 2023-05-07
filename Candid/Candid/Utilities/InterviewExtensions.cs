using Candid.Models;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;

namespace Candid.Utilities
{
    public static class InterviewExtensions
    {
        public static List<Candid.Models.Interview> GetUpcomingStudentInterviews(AppDbContext _context, AppUser Student)
        {
             return _context.Interviews
                    .Where(i => i.AppUserPosition.StudentId == Student.Id && i.InterviewDate > Student.SystemDate)
                    .Include(i => i.AppUserPosition).ThenInclude(aup => aup.Position)
                    .Include(i => i.Recruiter).ToList();
        }
    }
}