using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Dto.Common;
namespace GreyHound.Dto.Classifieds
{
    public class PupsSaleDto
    {
        public int AddId { get; set; }
        public int LittlerSaleId { get; set; }
        public int SireId { get; set; }
        public string SireName { get; set; }
        public int DamId { get; set; }
        public string DamName { get; set; }
        public List<ImageDto> ImageUrls { get; set; }       
        public string DateOfBirth { get; set; }        
        public string Currency { get; set; }
        public string Price { get; set; }
        public string Comment { get; set; }

        public int AddCountryId { get; set; }
        public string AddCountryName { get; set; }
        
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? KennelId { get; set; }
        public string KennelName { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RePostedDate { get; set; }
        public int PostedUserId { get; set; }
        public bool Deletable { get; set; }
    }

    public class PupsSaleCountriesDto
    {
        public int? CountryId { get; set; }
        public bool IsMain { get; set; }
        public string CountryName { get; set; }
        public int AdsCount { get; set; }
    }

    public class KennelInfoDto
    {
        public int KennelId { get; set; }
        public string KennelName { get; set; }
    }

    public class SearchPupSalesDto
    {
        public int CountryId { get; set; }
        public int? KennelId { get; set; }
        public int? SireId { get; set; }
        public int UserId { get; set; }
    }

    public class SavePupSaleDto
    {
        public int SireId { get; set; }
        public int DamId { get; set; }
        public string DateOfBirth { get; set; }
        public int CurrencyId { get; set; }
        public string Price { get; set; }       
        public int? KennelId { get; set; }        
    }

    public class UpdatePupSaleDto
    {
        public int AddId { get; set; }
        public int SaleId { get; set; }
        public int SireId { get; set; }
        public int DamId { get; set; }
        public string DateOfBirth { get; set; }
        public int CurrencyId { get; set; }
        public string Price { get; set; }
        public int? KennelId { get; set; }
    }
}
