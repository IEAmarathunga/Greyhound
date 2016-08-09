using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Users
{
    public class Role
    {
        [Key]
        public int Role_Id { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string Role_Name { get; set; }
    }
}
