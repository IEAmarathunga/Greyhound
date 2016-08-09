using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Tracks
{
    public class Track
    {
        [Key]
        public int Trk_Id { get; set; }
        
        [Required]
        [ForeignKey("Stadium")]
        public int Trk_StadiumId { get; set; }

        [Required]
        [ForeignKey("TrackDistance")]
        public int Trk_DistanceId { get; set; }

        [Required]
        [ForeignKey("TrackType")]
        public int Trk_TrackTypeId { get; set; }

        [ForeignKey("Trk_StadiumId")]
        public virtual Stadium Stadium { get; set; }
        
        [ForeignKey("Trk_DistanceId")]
        public virtual TrackDistance TrackDistance { get; set; }

        [ForeignKey("Trk_TrackTypeId")]
        public virtual TrackType TrackType { get; set; }
    }
}
