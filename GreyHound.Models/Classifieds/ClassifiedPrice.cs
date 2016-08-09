using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Classifieds
{
    public class ClassifiedPrice
    {
        [Key]
        public int Price_Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Price_DisplayValue { get; set; }

        [Required]
        public decimal Price_FromValue { get; set; }

        [Required]
        public decimal Price_ToValue { get; set; }
    }
}
