using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Candid.Models
{
    public class AppUserMajor
    {
        public bool isActive { get; set; } = true;
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}