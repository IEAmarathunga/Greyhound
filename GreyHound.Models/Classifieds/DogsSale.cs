using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GreyHound.Models.Common;

namespace GreyHound.Models.Classifieds
{
    public class DogsSale
    {
        [Key]
        public int DogSale_Id { get; set; }

        [Required]
        [ForeignKey("Add")]
        public int DogSale_AddId { get; set; }

        [Required]
        [ForeignKey("Dog")]
        public int DogSale_DogId { get; set; }

        [Required]
        [ForeignKey("SaleType")]
        public int DogSale_SaleTypeId { get; set; }
                
        [ForeignKey("Currency")]
        public int? DogSale_CurrencyId { get; set; }

        //[StringLength(100)]
        //public string DogSale_Unit { get; set; }

        public decimal? DogSale_Price { get; set; } //8,2

        [ForeignKey("DogSale_AddId")]
        public virtual Advertisement Add { get; set; }

        [ForeignKey("DogId")]
        public virtual Dogs.Dog Dog { get; set; }

        [ForeignKey("DogSale_SaleTypeId")]
        public virtual DogSaleType SaleType { get; set; }

        [ForeignKey("DogSale_CurrencyId")]
        public virtual Currency Currency { get; set; }
        
        /*
        //contact details
        [StringLength(50, MinimumLength = 2)]
        public string DogSale_SellerName { get; set; }
         
        [StringLength(50, MinimumLength = 2)]
        public string DogSale_SellerPhone { get; set; }

        [ForeignKey("Country")]
        public int DogSale_CountryId { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string DogSale_Zip { get; set; }
        
        [StringLength(100, MinimumLength = 2)]
        public string DogSale_City { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string DogSale_Street { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string DogSale_Email { get; set; }
        
        public string DogSale_Comment { get; set; }
         
        */
    }
}
