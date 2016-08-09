using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Tracks
{
    [Table("Stadiums")]
    public class Stadium
    {
        [Key]
        public int Stadium_Id { get; set; }

        [Required()]
        //[Index(IsUnique = true)]
        [StringLength(15, MinimumLength = 2)]
        public string Stadium_Code { get; set; }
        
        [Required()]       
        [StringLength(30, MinimumLength = 2)]
        public string Stadium_Name { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string Stadium_DisplayName { get; set; }
        
        [ForeignKey("Country")]
        public int Stadium_CountryId { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Stadiumy_Address { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string Stadium_Url { get; set; }
                
        [StringLength(100, MinimumLength = 2)]
        public string Stadium_Phone { get; set; }

        //modelBuilder.Entity<MyClass>().Property(x => x.SnachCount).HasPrecision(10,4);
        public decimal? Stadium_Latitude { get; set; }
        public decimal? Stadium_Longitude { get; set; }

        public string Stadium_Description { get; set; }

        [ForeignKey("Stadium_CountryId")]
        public virtual Common.Country Country { get; set; }
    }
}
