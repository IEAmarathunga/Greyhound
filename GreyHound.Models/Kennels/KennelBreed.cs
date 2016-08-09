using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Kennels
{
    public class KennelBreed
    {
        [Key]
        public int KenBreed_Id { get; set; }

        [ForeignKey("Kennel")]
        public int KenBreed_KennelId { get; set; }

        [ForeignKey("Dog")]
        public int KenBreed_DogId { get; set; }

        [ForeignKey("KenBreed_DogId")]
        public virtual Dogs.Dog Dog { get; set; }

        [ForeignKey("KenBreed_KennelId")]
        public virtual Kennel Kennel { get; set; }
    }
}
