using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Candid.Models
{

    public class AppUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        // Account Creation Date
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime? LastLoginDate { get; set; } = null;

        // System date field for testing
        public DateTime SystemDate { get; set; } = DateTime.Now;

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; } = null;

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        /******* Properties for Student *******/
        public Gender Gender { get; set; }

        public Ethnicity Ethnicity { get; set; }

        [Display(Name = "GPA")]
        [Range(0.0, 4.0, ErrorMessage = "Invalid GPA Value")]
        public decimal GPA { get; set; }

        [Display(Name = "Graduation Date")]
        public DateTime? GraduationDate { get; set; } = null;

        public PositionType PositionType { get; set; }

        // Many to many for students to majors
        public List<AppUserMajor> AppUserMajors { get; set; }

        // One to many for student to interviews
        // [InverseProperty("Student")]
        // public List<Interview> StudentInterviews { get; set; }

        // Linking student to join table for position ... i.e. applications
        public List<AppUserPosition> AppUserPositions { get; set; }

        /******* Properties for Recruiter *******/

        // one-to-many relationship for companies to recruiters
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        // One to many for recruiter to interviews
        [InverseProperty("Recruiter")]
        public List<Interview> RecruiterInterviews { get; set; }
    }
}
