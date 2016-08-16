using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Dto.Classifieds;
using GreyHound.Dto.Dogs;
using System.Net.Http;
using GreyHound.Dto.Users;

namespace GreyHound.WebApplication.Controllers.Classifieds
{
    public interface IClassifiedService
    {
        List<SireDto> GetSiresAsync();

        Task<ClassifiedUserStatDto> GetClassifiedUserStatsAsync(int userId);
        Task<ClassifiedStatsDto> GetClassifiedStatsAsync();

        #region Litter Sale

        Task<List<KennelInfoDto>> GetKennelsByCountryGroupIdAsync(int countryGroupId);
        
        Task<List<CountryDto>> GetPupSalesCountryGroupsAsync(int groupId);
        Task<List<CountryGroupDto>> GetPupSalesCountriesAsync();
        Task<List<PupsSaleDto>> GetLitterAdsAsync(SearchPupSalesDto dto);        

        #endregion

        #region Dog Sales

        Task<List<DogSaleTypesDto>> GetDogSaleTypesAsync();
        Task<List<DogSalePricesDto>> GetPricesAsync();

        Task<List<CountryDto>> GetDogSalesCountryGroupsAsync(int groupId);
        Task<List<CountryGroupDto>> GetDogSalesCountriesAsync();
        Task<List<DogSaleDto>> GetDogAdsAsync(SearchDogSaleDto dto);

        #endregion

        #region Private Sales

        Task<List<CountryDto>> GetMiscSalesCountryGroupsAsync(int groupId, string SectionIds);
        Task<List<SectionAddsCountDto>> GetSectionAdsCountAsync(int groupId);

        #endregion

        #region Private and Business

        Task<List<MiscAddTypesDto>> GetMiscAdsTypes();
        Task<List<CountryGroupDto>> GetMiscSalesCountriesAsync(string types);
        Task<List<MiscAdsDto>> GetMiscellaneousAdsAsync(SearchMiscAdsDto dto);

        #endregion
        
        #region Post Adds

        //post addvertisement
        Task<int?> PostAdvertisementAsync(SaveAddDto dto);

        //post pup/litter sale 
        Task<int?> PostLitterAdsAsync(SaveAddDto addDto, SavePupSaleDto dto);
        Task<int?> UpdateLitterAdsAsync(UpdateAddDto addDto, UpdatePupSaleDto dto);
        
        //post dog sale add
        Task<int?> PostDogAdsAsync(SaveAddDto addDto, SaveDogSaleDto dto);
        Task<int?> UpdateDogAdsAsync(UpdateAddDto addDto, UpdateDogSaleDto dto);

        //post misc sale add
        Task<int?> PostMiscAdsAsync(SaveAddDto addDto, SaveMiscAdDto dto);
        Task<int?> UpdateMiscAdsAsync(UpdateAddDto addDto, UpdateMiscAdDto dto);
        
        #endregion

        #region Delete Ads

        Task<int?> DeleteAdAsync(DeleteAddDto dto);

        #endregion
    }
}
