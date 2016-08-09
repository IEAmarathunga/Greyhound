using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Dto.Common;
using GreyHound.Models.Enums;
using Newtonsoft.Json.Linq;

namespace GreyHound.WebApplication.Controllers.Common
{
    public interface IMasterDataService
    {
        ///Task<List<ColorCategoryDto>> GetColorCategoriessAsync();
        //Task<List<LandDto>> GetLandsAsync();
        Task<List<DogColorDto>> GetDogColorsAsync();
        Task<List<BreedDto>> GetBreedsAsync();
        Task<List<AgeGroupDto>> GetAgeGroupsAsync();
        Task<List<CurrencyDto>> GetCurrenciesAsync();
        Task<List<AllCountriesDto>> GetCountriesAsync();
        Task<List<AllCountriesDto>> GetCountryByIdAsync(int id);
        Task<List<MembershipTypeDto>> GetMemberTypes();
        Task<List<CountryGroupsDto>> GetCountryGroupsAsync();


        List<EnumTypeDto> GetMonths();        
    }
}