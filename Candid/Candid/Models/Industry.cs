using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class Industry
    {
        [Key]
        public int IndustryId { get; set; }

        [Required]
        public bool isActive { get; set; } = true;

        [Required]
        public IndustryTypes IndustryType { get; set; }

        // Many-to-many for industries to companies
        public List<CompanyIndustry> CompanyIndustries { get; set; }
    }
}
