using GreyHound.Models.Common;
using GreyHound.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Classifieds
{
    public class Advertisement
    {
        [Key]
        public int Ads_Id { get; set; }

        [Required]
        public string Ads_Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Ads_ContactName { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int Ads_CountryId { get; set; }

        [StringLength(20)]
        public string Ads_PostCode { get; set; }
        [StringLength(30)]
        public string Ads_City { get; set; }
        [StringLength(100)]
        public string Ads_Contact { get; set; }
        [StringLength(80)]
        public string Ads_Email { get; set; }
        [StringLength(100)]
        public string Ads_Address { get; set; }

        [Required]
        public int Ads_NoOfBumps { get; set; }
        [Required]
        public int Ads_CharCount { get; set; }

        //default false
        [Required]
        public bool Ads_IsVerified { get; set; }
                
        [ForeignKey("VerifiedUser")]
        public int? Ads_VerifiedBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? Ads_VerifiedDate { get; set; }
        
        [Required]
        [ForeignKey("CreatedUser")]
        public int Ads_CreatedBy { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime Ads_CreatedDate { get; set; }
                
        [ForeignKey("ModifiedUser")]
        public int? Ads_ModifiedBy { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime Ads_LastModifiedDate { get; set; }

        public bool Ads_IsDeleted { get; set; }

        [ForeignKey("DeletedUser")]
        public int? Ads_DeletedBy { get; set; }

        [StringLength(100)]
        public string Ads_DeleteComment { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? Ads_DeletedDate { get; set; }

        [ForeignKey("Ads_VerifiedBy")]
        public virtual User VerifiedUser { get; set; }

        [ForeignKey("Ads_CreatedBy")]
        public virtual User CreatedUser { get; set; }

        [ForeignKey("Ads_ModifiedBy")]
        public virtual User ModifiedUser { get; set; }

        [ForeignKey("Ads_DeletedBy")]
        public virtual User DeletedUser { get; set; }

        [ForeignKey("Country")]
        public virtual Country Country { get; set; }

        /*[InverseProperty("VerifiedUser")]
        public virtual ICollection<User> VUser { get; set; }
        [InverseProperty("CreatedUser")]
        public virtual ICollection<User> CUser { get; set; }*/
    }
}
