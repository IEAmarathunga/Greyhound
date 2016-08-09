using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Common
{
    public class AgeGroupDto
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public bool IsActive { get; set; }
    }
}
