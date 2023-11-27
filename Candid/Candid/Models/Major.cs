using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

// THIS MODEL IS COMPLETE. DO NOT TOUCH THIS EITHER
namespace Candid.Models
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }

        [Required]
        [Display(Name = "Major Name")]
        public string MajorName { get; set; }

        [Required]
        public bool isActive { get; set; } = true;

        [Required]
        [Display(Name = "Major Code")]
        public MajorCodes MajorCode { get; set; }

        // Many-to-many for students to majors
        public List<AppUserMajor> AppUserMajors { get; set; }

        // Many-to-many for Positions to Majors
        public List<PositionMajor> PositionMajors { get; set; }
    }
}
