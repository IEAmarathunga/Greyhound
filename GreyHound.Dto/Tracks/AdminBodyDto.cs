using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Tracks
{
    public class AdminBodyDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Url { get; set; }        
    }
}
