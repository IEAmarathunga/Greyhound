using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Common
{
    public class Country
    {        
        [Key]
        public int Country_Id { get; set; }
        
        [Required()]
        [Index(IsUnique = true)]
        [StringLength(10, MinimumLength = 2)]
        public string Country_Code { get; set; }
        
        [Required()]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2)]
        public string Country_Name { get; set; }
                
        [ForeignKey("CountryGroup")]
        public int Country_GroupId { get; set; }                

        public bool Country_HasTrack { get; set; }                
        public string Country_TrackDetails { get; set; }

        [ForeignKey("Country_GroupId")]
        public virtual CountryGroup CountryGroup { get; set; }
    }
}
