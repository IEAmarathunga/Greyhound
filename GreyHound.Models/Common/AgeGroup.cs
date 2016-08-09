using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Common
{
    public class AgeGroup
    {
        [Key]
        public int AgeGroup_Id { get; set; }
        
        [Required()]
        [Index(IsUnique=true)]
        [StringLength(50, MinimumLength = 4)]
        public string AgeGroup_Name { get; set; }
        
        [Required()]
        public int AgeGroup_From { get; set; }
        
        [Required()]
        public int AgeGroup_To { get; set; }        
    }
}
