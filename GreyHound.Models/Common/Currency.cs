using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Common
{
    public class Currency
    {        

        [Key]
        public int Currency_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(10, MinimumLength = 2)]
        public string Currency_Code { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 2)]
        public string Currency_Name { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(5, MinimumLength = 1)]
        public string Currency_Symbol { get; set; }       
        
    }
}
