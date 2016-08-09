using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Users
{
    public class MembershipType
    {
        [Key]
        public int MemType_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string MemType_Name { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string MemType_Description { get; set; }
        
        [Required]
        public decimal MemType_Price { get; set; } //5,2
        
        [Required]
        public int MemType_ValidDays { get; set; }
        
        [Required]
        public int MemType_AdsExpireDays { get; set; }

        [Required]
        public int MemType_CharCount { get; set; }
        
        [Required]
        public int MemType_AdsCount { get; set; }

        [Required]
        public int MemType_ImageCount { get; set; }

        [Required]
        public int MemType_VideoCount { get; set; }
    }
}
