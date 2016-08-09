using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Kennels
{
    public class KennelBrood
    {
        [Key]
        public int KenBrood_Id { get; set; }

        [ForeignKey("Kennel")]
        public int KenBrood_KennelId { get; set; }

        [ForeignKey("Dog")]
        public int KenBrood_DogId { get; set; }
        
        [ForeignKey("KenBrood_KennelId")]
        public virtual Kennel Kennel { get; set; }

        [ForeignKey("KenBrood_DogId")]
        public virtual Dogs.Dog Dog { get; set; }

    }
}
