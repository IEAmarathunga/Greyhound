using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Users
{
    public class MembershipDto
    {
        public int MemberTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public string State { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
    }
}
