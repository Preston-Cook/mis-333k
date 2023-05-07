using Microsoft.AspNetCore.Mvc;
using Candid.DAL;
using Candid.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Candid.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(Int32? StatusCode)
        {
            // Check if no status code was specified
            if (StatusCode == null)
            {
                return BadRequest();
            }

            // Check if status code in relevant range
            if (!(400 <= StatusCode && StatusCode <= 451) && !(500 <= StatusCode && StatusCode <= 511))
            {
                return BadRequest();
            }

            // Add status code to viewbag and return view to user
            ViewBag.StatusCode = StatusCode;

            return View();
        }
    }
}