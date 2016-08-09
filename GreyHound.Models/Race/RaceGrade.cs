using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GreyHound.Models.Race
{
    public class RaceGrade
    {
        [Key]
        public int Grade_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(20, MinimumLength = 2)]
        public string Grade_Name { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        public int Grade_Order { get; set; }
                
        public bool Grade_IsMajor { get; set; }
        public bool Grade_IsFeature { get; set; }
    }
}
