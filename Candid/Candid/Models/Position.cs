using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// THIS MODEL IS COMPLETE FOR NOW
namespace Candid.Models
{
    public class Position
    {
        [Key]
        public Int32 PositionId { get; set; }

        [Required]
        public String PositionName { get; set; }

        public String? PositionDescription { get; set; }        

        [Required]
        public Boolean isActive { get; set; } = true;

        [Required]
        public PositionType PositionType { get; set; }

        [ForeignKey("AddressId")]
        public Int32 AddressId { get; set; }
        public Address Address { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        // One-to-many for company to positions
        public Int32? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        // Many to many for positions to majors
        public List<PositionMajor> PositionMajors { get; set; }

        // Relationship to students
        public List<AppUserPosition> AppUserPositions { get; set; } // i.e. applications
    }
}