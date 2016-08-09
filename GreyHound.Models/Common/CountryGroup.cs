using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GreyHound.Models.Common
{
    public class CountryGroup
    {
        [Key]
        public int Group_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(30, MinimumLength = 2)]
        public string Group_Name { get; set; }
    }
}
