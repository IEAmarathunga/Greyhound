using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Classifieds
{
    public class KennelByCountryGroupDto
    {
        public int KennelId { get; set; }
        public string KennelName { get; set; }
    }

    public class CountryGroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int AdsCount { get; set; }
        public int? CountryCount { get; set; }
    }

    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int AdsCount { get; set; }
    }

    public class SaveAddDto
    {
        public string Description { get; set; }
        public string ContactName { get; set; }
        public int CountryId { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
    
    public class UpdateAddDto
    {
        public int AddId { get; set; }
        public string Description { get; set; }
        public string ContactName { get; set; }
        public int CountryId { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }

    public class DeleteAddDto
    {
        public int UserId { get; set; }
        public int AddId { get; set; }
        public string Comment { get; set; }
    }

    public class ClassifiedStatsDto
    {
        public int OnlinePupAds { get; set; }
        public int PupAdsViewsThisWeek { get; set; }
        public int PupAdsViewLastWeek { get; set; }

        public int OnlineDogAds { get; set; }
        public int DogAdsViewsThisWeek { get; set; }
        public int DogAdsViewLastWeek { get; set; }

        public int OnlinePrvtAds { get; set; }
        public int PrvtAdsViewsThisWeek { get; set; }
        public int PrvtAdsViewLastWeek { get; set; }

        public int OnlineBsnAds { get; set; }
        public int BsnAdsViewsThisWeek { get; set; }
        public int BsnAdsViewLastWeek { get; set; }
    }
    
}
