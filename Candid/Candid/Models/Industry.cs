using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class Industry
    {
        [Key]
        public Int32 IndustryId { get; set; }

        [Required]
        public Boolean isActive { get; set; } = true;

        [Required]
        public IndustryTypes IndustryType { get; set; }

        // Many-to-many for industries to companies
        public List<CompanyIndustry> CompanyIndustries { get; set; }
    }
}
