using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreyHound.Models.Common
{
    public class Breed
    {
        [Key]
        public int Breed_Id { get; set; }
        
        [Required()]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 2)]
        public string Breed_Name { get; set; }
        
    }
}
