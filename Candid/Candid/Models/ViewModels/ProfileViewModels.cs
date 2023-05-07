using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class StudentProfileViewModel
    {
        public String StudentId { get; set; }

        public Boolean isActive { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        public List<MajorCodes> Majors { get; set; }

        [Required]
        [Display(Name = "Graduation Date")]
        public DateTime GraduationDate { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "Invalid GPA Value")]        
        public Decimal GPA { get; set; }
        
        [Required]
        public Ethnicity Ethnicity { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Position Type")]
        public PositionType PositionType { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public String Street { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLogin { get; set; }
    }

    public class RecruiterProfileViewModel
    {
        public String RecruiterId { get; set; }

        public Boolean isActive { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        public String FirstName { get; set; }

        [Display(Name ="Last Name")]
        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        public String LastName { get; set; }

        public Int32 CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        public String CompanyDescription { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Company Email")]
        public String CompanyEmail { get; set; }
        
        [Required]
        [Display(Name = "Company Industries")]
        public List<IndustryTypes> IndustryTypes { get; set; } = new List<IndustryTypes>();

        [Url]
        [Display(Name = "Company Website")]
        public String? WebsiteUrl { get; set; }
        
        [Required]
        public String City { get; set; }

        [Required]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        public String Street { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Postal Code")]
        public String PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLogin { get; set; }
    }

    public class AdminProfileViewModel
    {
        public String AdminId { get; set; }

        public Boolean isActive { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public String FirstName { get; set; }

        [Display(Name ="Last Name")]
        [Required]
        public String LastName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastLogin { get; set; }
    }
}