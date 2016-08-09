using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Common
{
    public class DogTrainer
    {
        [Key]
        public int Trainer_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Trainer_Name { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Trainer_Email { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Trainer_Address { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Trainer_Phone { get; set; }
    }
}
