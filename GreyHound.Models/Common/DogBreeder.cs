using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Common
{
    public class DogBreeder
    {
        [Key]
        public int Breeder_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Breeder_Name { get; set; }

        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 2)]
        public string Breeder_Email { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Breeder_Address { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Breeder_Phone { get; set; }
    }
}
