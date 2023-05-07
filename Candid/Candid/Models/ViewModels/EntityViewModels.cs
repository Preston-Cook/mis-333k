using System.ComponentModel.DataAnnotations;

namespace Candid.Models
{
    public class CompanyViewModel
    {
        public Int32 CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }
        
        [Required]
        [Display(Name = "Industry Types")]
        public List<IndustryTypes> IndustryTypes { get; set; } = new List<IndustryTypes>();

        [Display(Name = "Company Email")]
        [EmailAddress]
        public String CompanyEmail { get; set; }

        [Display(Name = "Company Website")]
        [Url]
        public String? WebsiteUrl { get; set; }

        [Display(Name = "Company Description")]
        public String CompanyDescription { get; set; }
        
        [Display(Name = "City")]
        [Required]
        public String City { get; set; }

        [Display(Name = "Street")]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        [Required]
        public String Street { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Postal Code")]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }
    }

    public class PositionViewModel
    {
        public Int32 PositionId { get; set; }

        [Required]
        [Display(Name = "Position Name")]
        public String PositionName { get; set; }
        
        [Display(Name = "Company Name")]
        public Int32 CompanyId { get; set; }

        [Display(Name = "Position Description")]
        public String PositionDescription { get; set; }

        [Required]
        [Display(Name = "Position Majors")]
        public List<MajorCodes> Majors { get; set; } = new List<MajorCodes>();

        [Required]
        [Display(Name = "Application Deadline")]
        public DateTime Deadline { get; set; } = DateTime.Now.AddMonths(1);

        [Required]
        [Display(Name = "Position Type")]
        public PositionType PositionType { get; set; }

        [Display(Name = "City")]
        [Required]
        public String City { get; set; }

        [Display(Name = "Street")]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        [Required]
        public String Street { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Postal Code")]
        [Display(Name = "Postal Code")]
        public String PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }
    }

    public class AdminPositionViewModel : PositionViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public String CompanyName { get; set; }
    }

    public class ApplicationViewModel
    {
        public String StudentId { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime GraduationDate { get; set; }

        public Ethnicity Ethnicity { get; set; }
        public Gender Gender { get; set; }

        public Decimal GPA { get; set; }

        public String Majors { get; set; }

        [Required]
        public List<Int32> Positions { get; set; } = new List<Int32>();

    }

    public class InterviewRecruiterViewModel
    {
        [Required]
        [Display(Name = "Interviewer")]
        public String RecruiterId { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public RoomType RoomType { get; set; }
        [Required]
        [Display(Name = "Interview Date")]
        public DateTime InterviewDate { get; set; }

        public String UserId { get; set; }
    }

    public class InterviewAdminViewModel
    {
        [Display(Name = "Room Number")]
        public RoomType RoomType { get; set; }
        [Required]
        [Display(Name = "Interview Date")]
        public DateTime InterviewDate { get; set; }
    }

    public class InterviewStudentViewModel
    {
        
        [Required]
        public Int32 AppUserPositionId { get; set; }

        [Required]
        public Int32 InterviewId { get; set; }
    }
}