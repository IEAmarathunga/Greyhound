using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Common
{
    public class MembershipTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ValidDays { get; set; }
        public int CharCount { get; set; }
        public int AdsExpireDays { get; set; }
    }
}
