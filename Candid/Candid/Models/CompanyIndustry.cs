using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Candid.Models
{
    public class CompanyIndustry
    {
        public Boolean isActive { get; set; } = true;
        public Int32 CompanyId { get; set; }
        public Company Company { get; set; }

        public Int32 IndustryId { get; set; }
        public Industry Industry { get; set; }
    }
}