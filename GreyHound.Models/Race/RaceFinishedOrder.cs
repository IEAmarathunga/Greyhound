using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreyHound.Models.Race
{
    public class RaceFinishedOrder
    {
        [Key]
        public int FinOrder_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(5, MinimumLength = 2)]
        public string FinOrder_Value { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        public int FinOrder_Order { get; set; }
    }
}
