using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Common
{    
    public class AllCountriesDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class MainCountriesDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class OtherCountriesDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CountryGroupsDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }


}
