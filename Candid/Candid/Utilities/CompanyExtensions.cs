using Candid.Models;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Candid.Utilities
{
    public static class CompanyExtensions
    {
        public static IIncludableQueryable<Company, Industry> GetAllCompanies(AppDbContext _context, Boolean IncludeDeactivated)
        {
            IIncludableQueryable<Company, Industry> Companies;
            
            if (IncludeDeactivated)
            {
                Companies = _context.Companies
                    .Where(c => c.CompanyName.ToLower() != "candid")
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }
            else
            {
                Companies = _context.Companies
                    .Where(c => c.CompanyName.ToLower() != "candid" && c.isActive)
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }

            return Companies;
        }

        public async static Task<Company> GetCompanyById(AppDbContext _context, Int32 CompanyId, Boolean IncludeDeactivated)
        {
            Company Company;

            if (IncludeDeactivated)
            {
                Company =  await _context.Companies
                    .Where(c => c.CompanyId == CompanyId)
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry)
                    .FirstOrDefaultAsync();
            }
            else
            {
                Company = await _context.Companies
                    .Where(c => c.CompanyId == CompanyId && c.isActive)
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry)
                    .FirstOrDefaultAsync();
            }

            return Company;
        }

        public static CompanyViewModel CreateCompanyViewModel(Company Company)
        {
            var IndustryTypes = Company.CompanyIndustries.Where(ci => ci.isActive).Select(ci => ci.Industry.IndustryType).ToList();

            return new CompanyViewModel
            {
                CompanyId = Company.CompanyId,
                CompanyName = Company.CompanyName,
                IndustryTypes = IndustryTypes,
                CompanyEmail = Company.CompanyEmail,
                WebsiteUrl = Company.WebsiteUrl,
                CompanyDescription = Company.CompanyDescription,
                City = Company.Address.City,
                Street = Company.Address.Street,
                PostalCode = Company.Address.PostalCode,
                State = Company.Address.State
            };
        }

        public static IIncludableQueryable<Company, Industry> BasicSearchCompanies(String q, AppDbContext _context, Boolean IncludeDeactivated)
        {
            IIncludableQueryable<Company, Industry> Companies;

            if (IncludeDeactivated)
            {
                Companies = _context.Companies.Where(c => c.CompanyName.ToLower().Contains(q.ToLower()) && c.CompanyName.ToLower() != "candid")
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }
            else
            {
                Companies = _context.Companies.Where(c => c.isActive && c.CompanyName.ToLower().Contains(q.ToLower()) && c.CompanyName.ToLower() != "candid")
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }

            return Companies;
        }


        public static IIncludableQueryable<Candid.Models.Company, Candid.Models.Industry> SearchCompanies(CompanySearchViewModel csvm, AppDbContext _context, Boolean IncludeDeativated)
        {
            var Companies = GetAllCompanies(_context, IncludeDeativated);

            if (csvm.State != null)
            {
                Companies = Companies
                    .Where(c => c.Address.State == csvm.State)
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);;
            }

            if (csvm.City != null)
            {
                Companies = Companies
                    .Where(c => c.Address.City.ToLower().Contains(csvm.City.ToLower()))
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);;
            }

            if (csvm.CompanyName != null)
            {
                Companies = Companies
                    .Where(c => c.CompanyName.ToLower().Contains(csvm.CompanyName.ToLower()))
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }

            if (csvm.PositionType != null)
            {
                Companies = Companies
                    .Where(c => c.Positions.Any(p => p.PositionType == csvm.PositionType))
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }

            if (csvm.IndustryTypes.Count() >= 1)
            {
                Companies = Companies
                    .Where(c => c.CompanyIndustries.Where(ci => ci.isActive).Select(ci => ci.Industry.IndustryType).Any(i => csvm.IndustryTypes.Contains(i)))
                    .Include(c => c.Address)
                    .Include(c => c.Positions)
                    .Include(c => c.CompanyIndustries)
                    .ThenInclude(c => c.Industry);
            }

            return Companies;
        }

        public static IIncludableQueryable<Interview, Company> GetAvailableTimeslots(AppDbContext _context, DateTime PastDate, Int32 CompanyId)
        {
            return _context.Interviews
                    .Where(i => i.AppUserPositionId == null && i.InterviewDate > PastDate && i.Recruiter.CompanyId == CompanyId)
                    .Include(i => i.Recruiter)
                    .ThenInclude(r => r.Company);
        }
    }
}