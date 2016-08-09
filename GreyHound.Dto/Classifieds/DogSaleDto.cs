using GreyHound.Dto.Common;
using GreyHound.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Classifieds
{
    public class DogSaleTypesDto
    {        
        public int SaleTypeId { get; set; }
        public string SaleTypeName { get; set; }
        public bool HasPrice { get; set; }
    }

    public class DogSalePricesDto
    {
        public int? PriceId { get; set; }
        public string DisplayValue { get; set; }
        public decimal ValueFrom { get; set; }
        public decimal ValueTo { get; set; }
    }

    public class SearchDogSaleDto
    {
        public int CountryId { get; set; }
        public int? SireId { get; set; }
        public int? Gender { get; set; }
        public int? PriceId { get; set; }
        public int UserId { get; set; }
    }

    public class DogSaleDto
    {
        public int AddId { get; set; }
        public int DogSaleId { get; set; }        
        public string Name { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }           
        public int? ColorId { get; set; }
        public string Color { get; set; }        
        public DateTime? DOB { get; set; }
        public Gender Gender { get; set; }

        public List<ImageDto> ImageUrls { get; set; }       
        public int? CurrencyId { get; set; }
        public string Currency { get; set; }
        public decimal? Price { get; set; }
        public string Comment { get; set; }

        public int AddCountryId { get; set; }
        public string AddCountryName { get; set; }

        public string Contact { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
        public int PostedUserId { get; set; }
        public bool Deletable { get; set; }
    }

    public class SaveDogSaleDto
    {
        public int DogId { get; set; }
        public int SaleTypeId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Price { get; set; }                
    }

    public class UpdateDogSaleDto
    {
        public int SaleId { get; set; }
        public int DogId { get; set; }
        public int SaleTypeId { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? Price { get; set; }
    }
}
