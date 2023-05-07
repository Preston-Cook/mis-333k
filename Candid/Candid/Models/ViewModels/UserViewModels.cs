using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class StudentViewModel
    {
        public String StudentId { get; set; }

        public Boolean isActive { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        
        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
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
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        public String Street { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Postal Code")]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }
    }

    public class RecruiterViewModel
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

        [Required]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }
    }

    public class AdminViewModel
    {
        public String AdminId { get; set; }

        public Boolean isActive { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Required]
        public String FirstName { get; set; }

        [Display(Name ="Last Name")]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Required]
        public String LastName { get; set; }
    }

    public class AdminStudentViewModel
    {
        public String StudentId { get; set; }

        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Formatted Majors")]
        public String FormattedMajors { get; set; }

        [Display(Name = "GPA")]
        public Decimal GPA { get; set; }

        [Display(Name = "Ethnicity")]
        public String FormattedEthnicity { get; set; }

        public String FormattedAddress { get; set; }

        public String FormattedGender { get; set; }

        public String FormattedGraduationDate { get; set; }

        public Boolean IsActive { get; set; }

        [Required]
        [Display(Name = "Position")]
        public Int32 ApplicationId { get; set; }  
    }
}