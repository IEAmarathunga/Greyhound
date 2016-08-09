using GreyHound.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Common
{
    public class Image
    {
        [Key]
        public int Image_Id { get; set; }
        
        [Required()]
        public int Image_TypeId { get; set; }

        [Required()]
        public int Image_TransactionId { get; set; }

        [Required()]
        [StringLength(100)]
        public string Image_Name { get; set; }

        [Required()]
        [StringLength(500)]
        public string Image_Url { get; set; }

        //default true
        [Required]
        public bool Image_IsVerified { get; set; }

        [ForeignKey("VerifiedUser")]
        public int? Image_VerifiedBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? Image_VerifiedDate { get; set; }

        [ForeignKey("Image_VerifiedBy")]
        public virtual User VerifiedUser { get; set; }
    }
}
