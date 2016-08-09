using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreyHound.Models.Race
{
    public class RaceClass
    {
        [Key]
        public int RaceClass_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2)]
        public string RaceClass_Name { get; set; }
    }
}
