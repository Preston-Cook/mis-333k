using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candid.Models
{
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }

        [Required]
        public RoomType Room { get; set; }

        public bool isActive { get; set; } = true;

        [Required]
        public DateTime InterviewDate { get; set; }

        public string CreatorId { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // One to many for recruiter to interivews
        [ForeignKey("Recruiter")]
        public string RecruiterId { get; set; }
        public AppUser Recruiter { get; set; }

        // One to one for application
        public int? AppUserPositionId { get; set; }
        [ForeignKey("AppUserPositionId")]
        public AppUserPosition AppUserPosition { get; set; }
    }
}