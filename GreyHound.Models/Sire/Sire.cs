using GreyHound.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Sire
{
    public class Sire
    {
        [Key]
        public int Sire_Id { get; set; }

        [Required()]
        [ForeignKey("Dog")]
        public int Sire_DogId { get; set; }

        [Required()]        
        [StringLength(50, MinimumLength = 2)]
        public string Sire_Fee { get; set; }
        public string Sire_About { get; set; }
        public string Sire_Performance { get; set; }
        public string Sire_Progeny { get; set; }
        public string Sire_Terms { get; set; }

        public string Sire_StudBookLicensed { get; set; }

        [Required()]
        public string Sire_ChoiceOfSemen { get; set; }
        [Required()]
        public string Sire_SemenCountries { get; set; }
        [Required()]
        public string Sire_Contact { get; set; }
        public string Sire_Recommendation { get; set; }
        public bool? Sire_ActiveStatus { get; set; }

        [ForeignKey("Sire_DogId")]
        public virtual Dogs.Dog Dog { get; set; }

        //default false
        //[Required]
        public bool? Sire_IsVerified { get; set; }

        [ForeignKey("VerifiedUser")]
        public int? Sire_VerifiedBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? Sire_VerifiedDate { get; set; }

        //[Required]
        [ForeignKey("CreatedUser")]
        public int? Sire_CreatedBy { get; set; }

        //[Required]
        [Column(TypeName = "DateTime2")]
        public DateTime? Sire_CreatedDate { get; set; }

        [ForeignKey("ModifiedUser")]
        public int? Sire_ModifiedBy { get; set; }

        //[Required]
        [Column(TypeName = "DateTime2")]
        public DateTime? Sire_LastModifiedDate { get; set; }

        public bool? Sire_IsDeleted { get; set; }

        [ForeignKey("DeletedUser")]
        public int? Sire_DeletedBy { get; set; }

        [StringLength(100)]
        public string Sire_DeleteComment { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? Sire_DeletedDate { get; set; }

        [ForeignKey("Sire_VerifiedBy")]
        public virtual User VerifiedUser { get; set; }

        [ForeignKey("Sire_CreatedBy")]
        public virtual User CreatedUser { get; set; }

        [ForeignKey("Sire_ModifiedBy")]
        public virtual User ModifiedUser { get; set; }

        [ForeignKey("Sire_DeletedBy")]
        public virtual User DeletedUser { get; set; }


    }
}
