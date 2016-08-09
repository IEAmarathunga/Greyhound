using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GreyHound.Models.Common
{
    public class DogAdoptedOwner
    {
        [Key]
        public int AdpOwner_Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string AdpOwner_Name { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string AdpOwner_Email { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string AdpOwner_Address { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string AdpOwner_Phone { get; set; }
    }
}
