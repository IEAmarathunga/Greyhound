using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Users
{
    public class UserRole
    {
        [Key]
        public int UserRole_Id { get; set; }

        [Required()]
        [ForeignKey("User")]
        public int UserRole_UserId { get; set; }

        [Required()]
        [ForeignKey("Role")]
        public int UserRole_RoleId { get; set; }

        [ForeignKey("UserRoles_UserId")]
        public virtual User User { get; set; }
        [ForeignKey("UserRoles_RoleId")]
        public virtual Role Role { get; set; }
    }
}
