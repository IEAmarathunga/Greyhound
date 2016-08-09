using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Dogs
{
    public class TrainedDog
    {
        [Key]
        public int TrnDogs_Id { get; set; }

        [ForeignKey("DogTrainer")]
        public int TrnDogs_TrainerId { get; set; }

        [ForeignKey("Dog")]
        public int TrnDogs_DogId { get; set; }

        [ForeignKey("TrnDogs_TrainerId")]
        public virtual Common.DogTrainer DogTrainer { get; set; }

        [ForeignKey("TrnDogs_DogId")]
        public virtual Dog Dog { get; set; }
    }
}
