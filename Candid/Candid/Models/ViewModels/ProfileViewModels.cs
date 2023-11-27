using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class StudentProfileViewModel
    {
        public string StudentId { get; set; }

        public bool isActive { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public List<MajorCodes> Majors { get; set; }

        [Required]
        [Display(Name = "Graduation Date")]
        public DateTime GraduationDate { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "Invalid GPA Value")]
        public decimal GPA { get; set; }

        [Required]
        public Ethnicity Ethnicity { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Position Type")]
        public PositionType PositionType { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLogin { get; set; }
    }

    public class RecruiterProfileViewModel
    {
        public string RecruiterId { get; set; }

        public bool isActive { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        public string LastName { get; set; }

        public Int32 CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }

        [Required]
        [Display(Name = "Company Industries")]
        public List<IndustryTypes> IndustryTypes { get; set; } = new List<IndustryTypes>();

        [Url]
        [Display(Name = "Company Website")]
        public string? WebsiteUrl { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLogin { get; set; }
    }

    public class AdminProfileViewModel
    {
        public string AdminId { get; set; }

        public bool isActive { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLogin { get; set; }
    }
}