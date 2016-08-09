using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Common
{
    public class DogColor
    {
        [Key]
        public int DogColor_Id { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(10,MinimumLength = 2)]
        public string DogColor_Code { get; set; }
        
        /*[Required()]
        [ForeignKey("ColorCategory")]
        public int DogColor_CategoryId { get; set; }*/

        [Required()]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 2)]
        public string DogColor_Name { get; set; }

        /*[ForeignKey("DogColor_CategoryId")]
        public virtual ColorCategory ColorCategory{ get; set; }*/

    }
}
