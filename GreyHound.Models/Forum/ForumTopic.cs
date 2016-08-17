using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Forum
{
    public class ForumTopic
    {
        [Key]
        public int Topic_Id { get; set; }

        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string Topic_Name { get; set; }        
    }
}
