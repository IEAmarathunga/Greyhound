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
    public class Video
    {
        [Key]
        public int Video_Id { get; set; }

        [Required()]
        public int Video_TypeId { get; set; }

        [Required()]
        public int Video_TransactionId { get; set; }

        [Required()]
        [StringLength(100)]
        public string Video_Name { get; set; }

        [Required()]
        [StringLength(500)]
        public string Video_Url { get; set; }

        //default true
        [Required]
        public bool Video_IsVerified { get; set; }

        [ForeignKey("VerifiedUser")]
        public int? Video_VerifiedBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? Video_VerifiedDate { get; set; }

        [ForeignKey("Video_VerifiedBy")]
        public virtual User VerifiedUser { get; set; }
    }
}
