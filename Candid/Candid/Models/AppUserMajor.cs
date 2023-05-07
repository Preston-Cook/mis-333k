using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Candid.Models
{
    public class AppUserMajor
    {
        public Boolean isActive { get; set; } = true;
        public String AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Int32 MajorId { get; set; }
        public Major Major { get; set; }
    }
}