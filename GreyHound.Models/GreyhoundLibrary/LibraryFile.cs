using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreyHound.Models.GreyhoundLibrary
{
    public class LibraryFile
    {
        [Key]
        public int File_Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string File_DisplayName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string File_Name { get; set; }

        [Required]
        public string File_Size { get; set; }

        [Required]
        [ForeignKey("Library")]
        public int File_LibraryId { get; set; }

        [ForeignKey("File_LibraryId")]
        public virtual Library Library { get; set; }
    }
}
