using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Dogs
{
    public class BreededDog
    {
        [Key]
        public int BrdDogs_Id { get; set; }

        [ForeignKey("DogBreeder")]
        public int BrdDogs_BreederId { get; set; }

        [ForeignKey("Dog")]
        public int BrdDogs_DogId { get; set; }

        [ForeignKey("BrdDogs_BreederId")]
        public virtual Common.DogBreeder DogBreeder { get; set; }

        [ForeignKey("BrdDogs_DogId")]
        public virtual Dog Dog { get; set; }
    }
}
