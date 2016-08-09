using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Tracks
{
    public class AdminBody
    {
        [Key]
        public int AdminBody_Id { get; set; }

        [Required()]
        [Index(IsUnique=true)]
        [StringLength(50, MinimumLength = 2)]
        public string AdminBody_Name { get; set; }
        
        [ForeignKey("Country")]
        public int AdminBody_CountryId { get; set; }
        
        [StringLength(300, MinimumLength = 2)]
        public string AdminBody_Description { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string AdminBody_Address { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string AdminBody_Url { get; set; }

        [Index(IsUnique=true)]
        [StringLength(50, MinimumLength = 2)]
        public string AdminBody_Email { get; set; }
        
        [StringLength(50, MinimumLength = 2)]
        public string AdminBody_Contact { get; set; }

        [ForeignKey("AdminBody_CountryId")]
        public virtual Common.Country Country { get; set; }
    }
}
