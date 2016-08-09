using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Race
{
    public class RaceType
    {
        [Key]
        public int RaceType_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2)]
        public string RaceType_Name { get; set; }
    }
}
