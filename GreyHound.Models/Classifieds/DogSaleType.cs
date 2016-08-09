using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Classifieds
{
    public class DogSaleType
    {
        [Key]
        public int SaleType_Id { get; set; }

        [Required()]
        [StringLength(100)]
        public string SaleType_Name { get; set; }       

        //default false
        public bool SaleType_HasPrice { get; set; }
    }
}
