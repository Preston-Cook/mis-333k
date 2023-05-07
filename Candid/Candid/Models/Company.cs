using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Candid.Models
{
    public class Company
    {
        [Key]
        public Int32 CompanyId { get; set; }

        [Required]
        public String CompanyName { get; set; }

        [EmailAddress]
        public String CompanyEmail { get; set; }

        [ForeignKey("Address")]
        public Int32 AddressId { get; set;}
        public Address Address { get; set; }

        [Url]
        public String? WebsiteUrl { get; set; }

        [Required]
        public Boolean isActive { get; set; } = true;

        [Required]
        public String CompanyDescription { get; set; }

        // one to many relationship for company to recruiters
        public List<AppUser> Recruiters { get; set; }

        // One to many relationship for company to positions
        public List<Position> Positions { get; set; }

        // Many-to-many for industries to companies
        public List<CompanyIndustry> CompanyIndustries { get; set; } = new List<CompanyIndustry>();
    }
}
