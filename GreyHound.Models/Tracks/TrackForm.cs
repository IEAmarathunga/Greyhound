using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GreyHound.Models.Users;

namespace GreyHound.Models.Tracks
{
    public class TrackForm
    {
        [Key]
        public int TForm_Id { get; set; }

        [ForeignKey("Track")]
        public int TForm_TrackId { get; set; }

        [Required()]       
        public DateTime TForm_DateFrom { get; set; }

        [Required()]
        public DateTime TForm_DateTo { get; set; }

        public decimal? TForm_Time { get; set; }

        public bool TForm_IsDeleted { get; set; }

        [ForeignKey("DeletedUser")]
        public int? TForm_DeletedBy { get; set; }

        [StringLength(100)]
        public string TForm_DeleteComment { get; set; }

        public DateTime? TForm_DeletedDate { get; set; }

        [ForeignKey("TForm_TrackId")]
        public virtual Track Track { get; set; }

        [ForeignKey("TForm_DeletedBy")]
        public virtual User DeletedUser { get; set; }
    }
}
