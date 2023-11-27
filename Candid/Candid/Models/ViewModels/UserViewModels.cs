using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class StudentViewModel
    {
        public string StudentId { get; set; }

        public bool isActive { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

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
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Postal Code")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }
    }

    public class RecruiterViewModel
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

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }

    public class AdminViewModel
    {
        public string AdminId { get; set; }

        public bool isActive { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Required]
        public string LastName { get; set; }
    }

    public class AdminStudentViewModel
    {
        public string StudentId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Formatted Majors")]
        public string FormattedMajors { get; set; }

        [Display(Name = "GPA")]
        public Decimal GPA { get; set; }

        [Display(Name = "Ethnicity")]
        public string FormattedEthnicity { get; set; }

        public string FormattedAddress { get; set; }

        public string FormattedGender { get; set; }

        public string FormattedGraduationDate { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int ApplicationId { get; set; }
    }
}