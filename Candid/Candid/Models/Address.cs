using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candid.Models
{   
    public class Address
    {
        [Key]
        public Int32 AddressId { get; set; }

        [Required]
        public String Street { get; set; }

        public Decimal Lat { get; set; }

        public Decimal Lng { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public StateType State { get; set; }

        // Regex for Zip src: https://stackoverflow.com/questions/2577236/regex-for-zip-code
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Invalid Postal Code")]
        public String PostalCode { get; set; }
    }
}