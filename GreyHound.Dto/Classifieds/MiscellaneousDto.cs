using GreyHound.Dto.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Classifieds
{
    public class MiscAddTypesDto
    {
        public int AddTypeId { get; set; }
        public string AddTypeName { get; set; }
    }

    public class SearchMiscAdsDto
    {
        public int CountryGroupId { get; set; }
        public int? SectionId { get; set; }
        public int UserId { get; set; }
    }

    public class SectionAddsCountDto
    {
        public int? SectionId { get; set; }
        public string SectionName { get; set; }
        public int? AdsCount { get; set; }
    }

    public class MiscAdsDto
    {
        public int AddId { get; set; }
        public int MiscAddId { get; set; }
        public int SaleTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AddCountryId { get; set; }
        public string AddCountryName { get; set; }

        public string Contact { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }

        public List<ImageDto> ImageUrls { get; set; }
        public int PostedUserId { get; set; }
        public bool Deletable { get; set; }
    }

    public class SaveMiscAdDto
    {
        //public int AddId { get; set; }
        public int SaleTypeId { get; set; }
        public string Title { get; set; }
    }

    public class UpdateMiscAdDto
    {
        public int AddId { get; set; }
        public int MiscSaleId { get; set; }
        public int SaleTypeId { get; set; }
        public string Title { get; set; }
    }
}
