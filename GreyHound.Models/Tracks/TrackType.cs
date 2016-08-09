using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Tracks
{
    // track types : flat race, hurdle, coursing

    public class TrackType
    {
        [Key]
        public int TrkType_Id { get; set; }

        [Required()]
        [StringLength(50)]
        public string TrkrType_Name { get; set; }
    }
}
