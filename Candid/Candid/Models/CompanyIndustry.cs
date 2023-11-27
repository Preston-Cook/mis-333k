using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class CompanyIndustry
    {
        public bool isActive { get; set; } = true;
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
    }
}