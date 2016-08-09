using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreyHound.Models.Race
{
    public class RaceSpecialClass
    {
        [Key]
        public int SpecialClass_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2)]
        public string SpecialClass_Name { get; set; }
    }
}
