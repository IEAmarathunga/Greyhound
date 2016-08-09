using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GreyHound.Models.Dogs;

namespace GreyHound.Models.Classifieds
{
    public class LitterSale
    {
        [Key]
        public int LitSale_Id { get; set; }

        [Required]
        [ForeignKey("Add")]
        public int LitSale_AddId { get; set; }

        [Required]
        [ForeignKey("Sire")]
        public int LitSale_SireId { get; set; }

        [Required]
        [ForeignKey("Dam")]
        public int LitSale_DamId { get; set; }

        [Required]
        [ForeignKey("Currency")]
        public int LitSale_CurrencyId { get; set; }

        [StringLength(100)]
        public string LitSale_Price { get; set; }

        [StringLength(50)]
        public string LitSale_DateOfBirth { get; set; }

        [ForeignKey("Kennel")]
        public int? LitSale_KennelId { get; set; }

        [ForeignKey("LitSale_AddId")]
        public virtual Advertisement Add { get; set; }

        [ForeignKey("LitSale_SireId")]
        public virtual Dog Sire { get; set; }

        [ForeignKey("LitSale_DamId")]
        public virtual Dog Dam { get; set; }

        [ForeignKey("LitSale_CurrencyId")]
        public virtual Common.Currency Currency { get; set; }

        [ForeignKey("LitSale_KennelId")]
        public virtual Kennels.Kennel Kennel{ get; set; }

    }
}
