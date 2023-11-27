
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Candid.Models
{
    public class AppUserPosition
    {
        [Key]
        public int AppUserPositionId { get; set; }

        [Required]
        public StatusType StatusType { get; set; } = StatusType.Pending;

        public string StudentId { get; set; }
        public AppUser Student { get; set; }

        public Int32 PositionId { get; set; }
        public Position Position { get; set; }

        [Required]
        public bool isActive { get; set; } = true;

        [Required]
        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        // Potentially add storage for resume
        public Int32? InterviewId { get; set; }

        [ForeignKey("InterviewId")]
        public Interview Interview { get; set; }

        // Potentially add storage for cover letter
    }
}