using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Candid.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [EmailAddress]
        public string CompanyEmail { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [Url]
        public string? WebsiteUrl { get; set; }

        [Required]
        public bool isActive { get; set; } = true;

        [Required]
        public string CompanyDescription { get; set; }

        // one to many relationship for company to recruiters
        public List<AppUser> Recruiters { get; set; }

        // One to many relationship for company to positions
        public List<Position> Positions { get; set; }

        // Many-to-many for industries to companies
        public List<CompanyIndustry> CompanyIndustries { get; set; } = new List<CompanyIndustry>();
    }
}
