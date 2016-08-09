using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Classifieds
{
    public class MiscellaneousSale
    {
        [Key]
        public int MiscSale_Id { get; set; }

        [Required]
        [ForeignKey("Add")]
        public int MiscSale_AddId { get; set; }

        [Required]
        //[ForeignKey("MiscSaleType")]
        public int MiscSale_SaleTypeId { get; set; }

        [Required]
        public string MiscSale_Title { get; set; }

        //[Required]
        //public string MiscSale_Description { get; set; }

        [ForeignKey("MiscSale_AddId")]
        public virtual Advertisement Add { get; set; }

        //[ForeignKey("MiscSale_SaleTypeId")]
        //public virtual MiscSaleType MiscSaleType { get; set; }

    }
}
