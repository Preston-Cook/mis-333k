using System.ComponentModel.DataAnnotations;

namespace Candid.Models
{
    public class PositionSearchViewModel
    {   
        [Display(Name = "Position Name")]
        public String? PositionName { get; set; }

        [Display(Name = "Position Description")]
        public String? PositionDescription { get; set; }

        [Display(Name = "Position Type")]
        public PositionType? PositionType { get; set; }

        [Display(Name = "Company Name")]
        public Int32? CompanyId { get; set; }

        [Display(Name = "Industry Types")]
        public List<IndustryTypes> IndustryTypes { get; set; } = new List<IndustryTypes>();

        public StateType? State { get; set; }

        public String? City { get; set; }

        public List<MajorCodes> Majors { get; set; } = new List<MajorCodes>();

        public DateTime? Deadline { get; set; }

        [Required]
        public Boolean isBeforeDeadline { get; set; }
    }

    public class CompanySearchViewModel
    {
        [Display(Name = "State")]
        public StateType? State { get; set; }
        
        [Display(Name = "City")]
        public String? City { get; set; }

        [Display(Name = "Company Name")]
        public String? CompanyName { get; set; }

        [Display(Name = "Position Type")]
        public PositionType? PositionType { get; set; }

        [Display(Name = "Industry Types")]
        public List<IndustryTypes> IndustryTypes { get; set; } = new List<IndustryTypes>();
    }

    public class StudentSearchViewModel
    {
        [Display(Name = "First Name")]
        public String? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public String? LastName { get; set; }
        
        public List<MajorCodes> Majors { get; set; } = new List<MajorCodes>();

        public PositionType? PositionType { get; set; }

        [Display(Name = "Graduation Date")]
        public DateTime? GraduationDate { get; set; }

        public Boolean isAboveGraduationDate { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "Invalid GPA Value")]
        public Decimal? GPA { get; set; }

        public Boolean isAboveGPA { get; set; }
    }
}