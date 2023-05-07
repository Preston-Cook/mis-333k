using System.ComponentModel.DataAnnotations;

namespace Candid.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        public String UserId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Display(Name = "First Name")]
        
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression("^[a-zA-Z ,.'-]+$", ErrorMessage = "Invalid Name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class StudentRegisterModel : RegisterViewModel
    {
        [Required]
        public List<MajorCodes> Majors { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

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

    public class RecruiterRegisterModel : RegisterViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }

        public List<String> CompanyList { get; set; }
    }

    public class AdminRegisterModel : RegisterViewModel
    {

    }
}
