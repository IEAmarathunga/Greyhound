using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.Studbook
{
    public class Studbook
    {
        [Key]
        public int Studbook_Id { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string Studbook_Name { get; set; }
    }
}
