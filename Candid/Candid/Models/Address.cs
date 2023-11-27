using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candid.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string Street { get; set; }

        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public StateType State { get; set; }

        // Regex for Zip src: https://stackoverflow.com/questions/2577236/regex-for-zip-code
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }
    }
}