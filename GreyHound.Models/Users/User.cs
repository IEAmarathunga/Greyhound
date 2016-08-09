using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Users
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string User_FirstName { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string User_LastName { get; set; }

        [Required()]
        [StringLength(150, MinimumLength = 2)]
        public string User_Email { get; set; }

        [Required()]
        [StringLength(500, MinimumLength = 2)]
        public string User_Password { get; set; }
                
        [StringLength(100)]
        public string User_ContactNo { get; set; }
        
        [ForeignKey("MemberType")]
        public int? User_MemberTypeId { get; set; }

        public DateTime? User_MembershipActivatedDate { get; set; }

        [ForeignKey("Country")]
        public int? User_CountryId { get; set; }
               
        [StringLength(50)]
        public string User_State { get; set; }

        public Guid User_ActivationCode { get; set; }
        
        public bool User_EmailConfirmed { get; set; }
        public DateTime User_CodeGeneratedDate { get; set; }
        public DateTime? User_ActivatedDate { get; set; }

        //navigation properties
        [ForeignKey("User_MemberTypeId")]
        public virtual MembershipType MemberType { get; set; }

        [ForeignKey("User_CountryId")]
        public virtual Common.Country Country { get; set; }


    }
}
