 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Kennels
{
    public class Kennel
    {
        [Key]
        public int Ken_Id { get; set; }

        [Required()]        
        [StringLength(100, MinimumLength = 2)]
        public string Ken_Name { get; set; }

        [ForeignKey("Country")]
        public int Ken_CountryId { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Ken_BreederName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Ken_Street { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Ken_Zip { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Ken_City { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Ken_Email { get; set; }

        [StringLength(200, MinimumLength = 2)]
        public string Ken_Contact { get; set; }
                
        public string Ken_Description { get; set; }

        [ForeignKey("Ken_CountryId")]
        public virtual Common.Country Country { get; set; }
    }
}
