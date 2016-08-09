using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Tracks
{
    public class StadiumOpenDay
    {
        [Key]
        public int OpenDay_Id { get; set; }

        [ForeignKey("Stadium")]
        public int OpenDay_StadiumId { get; set; }        
        public int OpenDay_Value { get; set; }

        [ForeignKey("OpenDay_StadiumId")]
        public virtual Stadium Stadium { get; set; }
    }
}
