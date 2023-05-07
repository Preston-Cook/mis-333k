using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candid.Models
{
    public class Interview
    {
        [Key]
        public Int32 InterviewId { get; set; }

        [Required]
        public RoomType Room { get; set; }

        public Boolean isActive { get; set; } = true;

        [Required]
        public DateTime InterviewDate { get; set; }

        public String CreatorId { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        // One to many for recruiter to interivews
        [ForeignKey("Recruiter")]
        public String RecruiterId { get; set; }
        public AppUser Recruiter { get; set; }

        // One to one for application
        public Int32? AppUserPositionId { get; set; }
        [ForeignKey("AppUserPositionId")]
        public AppUserPosition AppUserPosition { get; set; }
    }
}