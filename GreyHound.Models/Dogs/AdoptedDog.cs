using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Dogs
{
    public class AdoptedDog
    {
        [Key]
        public int AdpDogs_Id { get; set; }

        [ForeignKey("DogAdoptedOwner")]
        public int AdpDogs_OwnerId { get; set; }

        [ForeignKey("Dog")]
        public int AdpDogs_DogId { get; set; }

        [ForeignKey("AdpDogs_OwnerId")]
        public virtual Common.DogAdoptedOwner DogAdoptedOwner { get; set; }

        [ForeignKey("AdpDogs_DogId")]
        public virtual Dog Dog { get; set; }
    }
}
