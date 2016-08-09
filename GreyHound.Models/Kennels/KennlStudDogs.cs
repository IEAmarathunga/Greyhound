using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Kennels
{
    public class KennlStudDogs
    {
        [Key]
        public int KenStud_Id { get; set; }
        
        [ForeignKey("Kennel")]
        public int KenStud_KennelId { get; set; }

        [ForeignKey("StudbookVolume")]
        public int KenStud_StudDogId { get; set; }
                
        [ForeignKey("KenStud_KennelId")]
        public virtual Kennel Kennel { get; set; }

        [ForeignKey("KenStud_StudDogId")]
        public virtual Studbook.StudbookVolume StudbookVolume { get; set; }

    }
}
