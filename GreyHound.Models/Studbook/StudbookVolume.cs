using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Studbook
{
    public class StudbookVolume
    {
        [Key]
        public int StudVol_Id { get; set; }
                
        public int StudVol_Volume { get; set; }

        [ForeignKey("Studbook")]
        public int StudVol_BookId { get; set; }

        [ForeignKey("Dog")]
        public int StudVol_DogId { get; set; }

        #region navigations

        [ForeignKey("StudVol_BookId")]
        public virtual Studbook Studbook { get; set; }

        [ForeignKey("StudVol_DogId")]
        public virtual Dogs.Dog Dog { get; set; }

        #endregion

    }
}
