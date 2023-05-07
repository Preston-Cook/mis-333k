using Candid.Models;
using Microsoft.AspNetCore.Identity;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Candid.Utilities
{
    public static class PositionExtensions
    {
        public static IIncludableQueryable<Position, Major> GetAllPositions(AppDbContext _context, Boolean IncludeDeativated, DateTime? PastDate = null)
        {
            IIncludableQueryable<Position, Major> Positions;

            if (PastDate == null && IncludeDeativated)
            {
                Positions = _context.Positions
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }
            
            else if (PastDate != null && IncludeDeativated)
            {
                Positions = _context.Positions
                    .Where(p => PastDate <= p.Deadline)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }
            
            else if (PastDate == null && !IncludeDeativated)
            {
                Positions = _context.Positions
                    .Where(p => p.isActive)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }
            else // (PastDate != null && !IncludeDeativated)
            {
                Positions = _context.Positions
                    .Where(p => PastDate <= p.Deadline && p.isActive)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            return Positions;
        }
        public async static Task<Position> GetPositionById(Int32 Id, AppDbContext _context, Boolean IncludeDeativated, DateTime? PastDate = null)
        {
            Position Position;

            if (PastDate == null && IncludeDeativated)
            {
                Position = await _context.Positions
                    .Where(p => p.PositionId == Id)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(p => p.Major)
                    .OrderBy(p => p.Deadline)
                    .FirstOrDefaultAsync();
            }
            else if (PastDate != null && IncludeDeativated)
            {
                Position = await _context.Positions
                    .Where(p => p.PositionId == Id && PastDate <= p.Deadline)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(p => p.Major)
                    .OrderBy(p => p.Deadline)
                    .FirstOrDefaultAsync();
            }
            else if (PastDate == null && !IncludeDeativated)
            {
                Position = await _context.Positions
                    .Where(p => p.PositionId == Id && p.isActive)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(p => p.Major)
                    .OrderBy(p => p.Deadline)
                    .FirstOrDefaultAsync();
            }
            else // (PastDate != null && !IncludeDeativated)
            {
                Position = await _context.Positions
                    .Where(p => p.PositionId == Id && PastDate <= p.Deadline && p.isActive)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(p => p.Major)
                    .OrderBy(p => p.Deadline)
                    .FirstOrDefaultAsync();
            }

            return Position;
        }

        public async static Task<Boolean> PositionContainsStudentMajors(AppDbContext _context, AppUser Student, Position Position)
        {
            // Get all of user's currently active majors and check if position contains them
            var UserMajors = await _context.AppUserMajors
                .Where(aum => aum.AppUserId == Student.Id && aum.isActive)
                .Include(aum => aum.Major)
                .Select(um => um.MajorId)
                .ToListAsync();
            
            var PostiionMajors = Position.PositionMajors.Select(pm => pm.MajorId).ToList();

            var Intersection = UserMajors.Intersect(PostiionMajors);

            return Intersection.Count() >= 1;
        }

        public async static Task<Boolean> PositionContainsStudentApplication(AppDbContext _context, AppUser Student, Position Position)
        {
            var app = await _context.AppUserPositions
                .Where(aup => aup.PositionId == Position.PositionId && aup.StudentId == Student.Id)
                .FirstOrDefaultAsync();
            
            return app != null;
        }

        public static async Task<Int32> CreatePosition(PositionViewModel pvm, AppDbContext _context)
        {
            // Check if position already exists
            var Position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == pvm.PositionName && p.Company.CompanyId == p.CompanyId && p.isActive);

            if (Position != null)
            {
                throw new Exception("Position Already Exists");
            }

            var AddrId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = pvm.Street, City = pvm.City, State = pvm.State, PostalCode = pvm.PostalCode }, _context);

            var NewPosition = new Position
            {
                PositionName = pvm.PositionName,
                PositionDescription = pvm.PositionDescription,
                PositionType = pvm.PositionType,
                AddressId = AddrId,
                Deadline = pvm.Deadline,
                CompanyId = pvm.CompanyId
            };

            await _context.AddAsync(NewPosition);
            await _context.SaveChangesAsync();

            foreach (var MajorCode in pvm.Majors)
            {
                var Major = await _context.Majors.FirstOrDefaultAsync(m => m.MajorCode == MajorCode);
                await _context.AddAsync(new PositionMajor { PositionId = NewPosition.PositionId, MajorId = Major.MajorId });
            }

            await _context.SaveChangesAsync();

            return NewPosition.PositionId;
        }

        public static async Task<Int32> CreatePosition(AdminPositionViewModel pvm, AppDbContext _context)
        {
            // Check if position already exists
            var Position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == pvm.PositionName && p.Company.CompanyId == p.CompanyId && p.isActive);

            if (Position != null)
            {
                throw new Exception("Position Already Exists");
            }

            var AddrId = await AddressExtensions.GetExistingOrCreatedId(new Address { Street = pvm.Street, City = pvm.City, State = pvm.State, PostalCode = pvm.PostalCode }, _context);

            var NewPosition = new Position
            {
                PositionName = pvm.PositionName,
                PositionDescription = pvm.PositionDescription,
                PositionType = pvm.PositionType,
                AddressId = AddrId,
                Deadline = pvm.Deadline,
                CompanyId = pvm.CompanyId
            };

            await _context.AddAsync(NewPosition);
            await _context.SaveChangesAsync();

            foreach (var MajorCode in pvm.Majors)
            {
                var Major = await _context.Majors.FirstOrDefaultAsync(m => m.MajorCode == MajorCode);
                await _context.AddAsync(new PositionMajor { PositionId = NewPosition.PositionId, MajorId = Major.MajorId });
            }

            await _context.SaveChangesAsync();

            return NewPosition.PositionId;
        }

        public static IIncludableQueryable<Position, Major> BasicSearchPositions(String q, AppDbContext _context, Boolean IncludeDeactivated, DateTime? PastDate = null)
        {
            IIncludableQueryable<Position, Major> Positions;

            if (PastDate == null && IncludeDeactivated)
            {
                Positions = _context.Positions
                    .Where(p => p.PositionName.ToLower().Contains(q.ToLower()) || p.Company.CompanyName.ToLower().Contains(q.ToLower()))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }
            else if (PastDate != null && IncludeDeactivated)
            {
                Positions = _context.Positions
                    .Where(p => p.Deadline > PastDate && (p.PositionName.ToLower().Contains(q.ToLower()) || p.Company.CompanyName.ToLower().Contains(q.ToLower())))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }
            else if (PastDate == null && !IncludeDeactivated)
            {
                Positions = _context.Positions
                    .Where(p => p.isActive && (p.PositionName.ToLower().Contains(q.ToLower()) || p.Company.CompanyName.ToLower().Contains(q.ToLower())))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }
            else // (PastDate != null && !IncludeDeativated)
            {
                Positions = _context.Positions
                    .Where(p => p.isActive && p.Deadline > PastDate && (p.PositionName.ToLower().Contains(q.ToLower()) || p.Company.CompanyName.ToLower().Contains(q.ToLower())))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            return Positions;
        }

        public static IIncludableQueryable<Position, Major> SearchPositions(PositionSearchViewModel psvm, AppDbContext _context, Boolean IncludeDeactivated, DateTime? PastDate = null)
        {
            IIncludableQueryable<Position, Major> Positions = GetAllPositions(_context, IncludeDeactivated, PastDate);

            if (psvm.PositionName != null)
            {
                Positions = Positions
                    .Where(p => p.PositionName.ToLower().Contains(psvm.PositionName.ToLower()))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.PositionDescription != null)
            {
                Positions = Positions
                    .Where(p => p.PositionDescription.ToLower().Contains(psvm.PositionDescription.ToLower()))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.PositionType != null)
            {
                Positions = Positions
                    .Where(p => p.PositionType == psvm.PositionType)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.CompanyId != null)
            {
                Positions = Positions
                    .Where(p => p.CompanyId == psvm.CompanyId)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);   
            }

            if (psvm.IndustryTypes.Count() >= 1)
            {
                
                Positions = Positions
                    .Where(p => p.Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => ci.Industry.IndustryType).Any(i => psvm.IndustryTypes.Contains(i)))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.State != null)
            {
                Positions = Positions
                    .Where(p => p.Address.State == psvm.State)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.City != null)
            {
                Positions = Positions
                    .Where(p => p.Address.City == psvm.City)
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.Majors.Count() >= 1)
            {
                Positions = Positions
                    .Where(p => p.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode).Any(mc => psvm.Majors.Contains(mc)))
                    .Include(p => p.Address)
                    .Include(p => p.Company)
                    .Include(p => p.PositionMajors)
                    .ThenInclude(pm => pm.Major);
            }

            if (psvm.Deadline != null)
            {
                if (psvm.isBeforeDeadline)
                {
                    Positions = Positions
                        .Where(p => p.Deadline <= psvm.Deadline)
                        .Include(p => p.Address)
                        .Include(p => p.Company)
                        .Include(p => p.PositionMajors)
                        .ThenInclude(pm => pm.Major);
                }
                else
                {
                    Positions = Positions
                        .Where(p => p.Deadline >= psvm.Deadline)
                        .Include(p => p.Address)
                        .Include(p => p.Company)
                        .Include(p => p.PositionMajors)
                        .ThenInclude(pm => pm.Major);
                }
            }

            return Positions;
        }

        public static PositionViewModel CreatePositionViewModel(Position Pos)
        {
            List<MajorCodes> MajorCodeList = Pos.PositionMajors.Where(pm => pm.isActive).Select(pm => pm.Major.MajorCode).ToList();

            return new PositionViewModel
            {
                PositionId = Pos.PositionId,
                PositionName = Pos.PositionName,
                CompanyId = Pos.Company.CompanyId,
                PositionDescription = Pos.PositionDescription,
                Majors = MajorCodeList,
                Deadline = Pos.Deadline,
                PositionType = Pos.PositionType,
                City = Pos.Address.City,
                Street = Pos.Address.Street,
                PostalCode = Pos.Address.PostalCode,
                State = Pos.Address.State
            };
        }
    }
}