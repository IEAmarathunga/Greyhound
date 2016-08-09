using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreyHound.Models.Race
{
    public class RaceResultType
    {
        [Key]
        public int ResultType_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(20, MinimumLength = 2)]
        public string ResultType_Name { get; set; }
    }
}
