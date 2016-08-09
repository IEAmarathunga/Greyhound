using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Users
{
    public class AudienceDto
    {
        public string ClientId { get; set; }
        public string Base64Secret { get; set; }
        public string Name { get; set; }
    }

}
