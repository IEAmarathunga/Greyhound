using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreyHound.Dto.Common
{
    public class DogColorDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }        
        public string Name { get; set; }
    }
}
