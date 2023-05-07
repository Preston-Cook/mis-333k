using Microsoft.AspNetCore.Mvc;
using Candid.DAL;
using Candid.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Candid.Utilities;

namespace Candid.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext db)
        {
            _context = db;
        }


        public async Task<IActionResult> Index()
        {
            // Weird work-around for interview bug
            if (_context.AppUserPositions.FirstOrDefault(aup => aup.InterviewId == 1) == null)
                {
                    var Apps = _context.AppUserPositions.ToList();

                    for (int i = 0; i < 14; i++)
                    {
                        Apps[i].InterviewId = i + 1;
                    }

                    await _context.SaveChangesAsync();
                }

            if (_context.Companies.Where(c => c.CompanyName == "Candid").FirstOrDefault() == null)
            {
                _context.Add(new Company
                {
                    AddressId = 81,
                    CompanyName = "Candid",
                    CompanyEmail = "support@candidcareers.co",
                    CompanyDescription = "Candid is a leading career services platform that connects college students and recent graduates with employers, providing resources and opportunities to help them achieve their professional aspirations.",
                    WebsiteUrl = "http://www.google.com"
                });

                await _context.SaveChangesAsync();

                // Associate all CSOs with Candid
                var admins = await AppUserExtensions.GetAllAdmins(_context, IncludeDeactivated: true);

                // Find Candid in database
                var Company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == "Candid");

                foreach (var admin in admins)
                {
                    admin.CompanyId = Company.CompanyId;
                }

                // Finish associating admins with Candid
                await _context.SaveChangesAsync();
            }

            return View();
        }
    }
}