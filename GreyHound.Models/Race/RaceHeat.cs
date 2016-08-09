using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Race
{
    public class RaceHeat
    {
        [Key]
        public int RaceHeat_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2)]
        public string RaceHeat_Name { get; set; }
    }
}
