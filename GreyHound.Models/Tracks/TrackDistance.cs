using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Tracks
{
    public class TrackDistance
    {
        [Key]
        public int TrDis_Id { get; set; }
        [Required]
        public decimal TrDis_LengthInMeter { get; set; }
    }
}
