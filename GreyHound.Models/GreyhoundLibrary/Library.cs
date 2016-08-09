using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.GreyhoundLibrary
{
    public class Library
    {
        [Key]
        public int Lib_Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Lib_Name { get; set; }
                
        [ForeignKey("Parent")]
        public int? Lib_ParentId { get; set; }

        [StringLength(1000)]
        public string Lib_Decription { get; set; }

        [StringLength(100)]
        public string Lib_Title { get; set; }

        [ForeignKey("Lib_ParentId")]
        public virtual Library Parent { get; set; }
    }
}
