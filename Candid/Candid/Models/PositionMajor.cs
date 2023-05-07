using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

// THIS MODEL IS COMPLETE DO NOT TOUCH <-- more a message for myself
namespace Candid.Models
{
    public class PositionMajor
    {
        public Boolean isActive { get; set; } = true;
        public Int32 PositionId { get; set; }
        public Position Position { get; set; }

        public Int32 MajorId { get; set; }
        public Major Major { get; set; }
    }
}