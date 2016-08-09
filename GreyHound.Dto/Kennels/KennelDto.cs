using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Kennels
{
    public class KennelDto
    {
        public int Id { get; set; }
        public string KennelName { get; set; }
        public string Breeder { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }   
    }

    public class KennelCountriesDto
    {
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsMainCountry { get; set; }
        public int KennelCount { get; set; }
    }

    public class KennelsDto
    {
        public int KennelId { get; set; }
        public string KennelName { get; set; }
        public string Country { get; set; }
        public string Breeder { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}
