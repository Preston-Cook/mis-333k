using System.ComponentModel.DataAnnotations;

namespace Candid.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Industry Types")]
        public List<IndustryTypes> IndustryTypes { get; set; } = new List<IndustryTypes>();

        [Display(Name = "Company Email")]
        [EmailAddress]
        public string CompanyEmail { get; set; }

        [Display(Name = "Company Website")]
        [Url]
        public string? WebsiteUrl { get; set; }

        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Street")]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        [Required]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Postal Code")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }
    }

    public class PositionViewModel
    {
        public int PositionId { get; set; }

        [Required]
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }

        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }

        [Display(Name = "Position Description")]
        public string PositionDescription { get; set; }

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
        public string City { get; set; }

        [Display(Name = "Street")]
        [RegularExpression(@"^\s*\S+(?:\s+\S+){2,4}$", ErrorMessage = "Invalid Address")]
        [Required]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Postal Code")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        public StateType State { get; set; }
    }

    public class AdminPositionViewModel : PositionViewModel
    {
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }

    public class ApplicationViewModel
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime GraduationDate { get; set; }

        public Ethnicity Ethnicity { get; set; }
        public Gender Gender { get; set; }

        public decimal GPA { get; set; }

        public string Majors { get; set; }

        [Required]
        public List<int> Positions { get; set; } = new List<int>();

    }

    public class InterviewRecruiterViewModel
    {
        [Required]
        [Display(Name = "Interviewer")]
        public string RecruiterId { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public RoomType RoomType { get; set; }
        [Required]
        [Display(Name = "Interview Date")]
        public DateTime InterviewDate { get; set; }

        public string UserId { get; set; }
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
        public int AppUserPositionId { get; set; }

        [Required]
        public int InterviewId { get; set; }
    }
}