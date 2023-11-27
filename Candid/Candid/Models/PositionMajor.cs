using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

// THIS MODEL IS COMPLETE DO NOT TOUCH <-- more a message for myself
namespace Candid.Models
{
    public class PositionMajor
    {
        public bool isActive { get; set; } = true;
        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}