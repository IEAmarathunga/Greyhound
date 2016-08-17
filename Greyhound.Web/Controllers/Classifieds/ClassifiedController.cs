using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using GreyHound.Dto.Classifieds;
using GreyHound.Models.Enums;
using Newtonsoft.Json.Linq;

namespace GreyHound.WebApplication.Controllers.Classifieds
{
    [RoutePrefix("api/Classifieds")]
    public class ClassifiedController : ApiController
    {
        private readonly IClassifiedService _service;

        public ClassifiedController()
        {
            _service = new ClassifiedService();
        }

        public ClassifiedController(IClassifiedService service)
        {
            _service = service;
        }
       
        [HttpGet]
        [Route("Sire")]
        public async Task<IHttpActionResult> GetSires()
        {
            var result = _service.GetSiresAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetClassifiedUserStats/{id}")]
        public async Task<IHttpActionResult> GetClassifiedUserStats(int id)
        {
            var result = await _service.GetClassifiedUserStatsAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("Stats")]
        public async Task<IHttpActionResult> GetClassifiedStats()
        {
            var result = await _service.GetClassifiedStatsAsync();
            return Ok(result);
        }

        #region Litter Sale

        [HttpGet]
        [Route("GetPupSaleKennels/{id}")]
        public async Task<IHttpActionResult> GetPupSaleKennels(int id)
        {
            var result = await _service.GetKennelsByCountryGroupIdAsync(id);
            return Ok(result);
        }
       
        [HttpGet]
        [Route("PupCountriesByGroup/{id}")]
        public async Task<IHttpActionResult> GetPupSalesCountryGroups(int id)
        {
            var result = await _service.GetPupSalesCountryGroupsAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("PupCountries")]
        public async Task<IHttpActionResult> GetPupSalesCountries()
        {
            var result = await _service.GetPupSalesCountriesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("LitterAds")]
        public async Task<IHttpActionResult> GetLitterAds(SearchPupSalesDto dto)
        {
            var result = await _service.GetLitterAdsAsync(dto);
            return Ok(result);
        }
       
        #endregion

        #region Dog Sale

        [HttpGet]
        [Route("SaleTypes")]
        public async Task<IHttpActionResult> GetSaleTypes()
        {
            var result = await _service.GetDogSaleTypesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Prices")]
        public async Task<IHttpActionResult> GetPrices()
        {
            var result = await _service.GetPricesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("DogCountriesByGroup/{id}")]
        public async Task<IHttpActionResult> GetDogSalesCountryGroups(int id)
        {
            var result = await _service.GetDogSalesCountryGroupsAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("DogCountries")]
        public async Task<IHttpActionResult> GetDogSalesCountries()
        {
            var result = await _service.GetDogSalesCountriesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("DogAds")]
        public async Task<IHttpActionResult> GetDogAds(SearchDogSaleDto dto)
        {
            var result = await _service.GetDogAdsAsync(dto);
            return Ok(result);
        }

        #endregion

        #region Private Sales

        [HttpGet]
        [Route("PrivateSaleCountries")]
        public async Task<IHttpActionResult> GetPrivateSalesCountries()
        {
            string types = ((int)ClassifiedSection.PrivateSale).ToString() + "," + ((int)ClassifiedSection.PrivateWanted).ToString();

            var result = await _service.GetMiscSalesCountriesAsync(types);
            return Ok(result);
        }

        [HttpGet]
        [Route("PrvSaleCountriesByGroup/{id}")]
        public async Task<IHttpActionResult> GetPrivateSalesCountryGroups(int id)
        {
            string types = ((int)ClassifiedSection.PrivateSale).ToString() + "," + ((int)ClassifiedSection.PrivateWanted).ToString();

            var result = await _service.GetMiscSalesCountryGroupsAsync(id, types);
            return Ok(result);
        }

        [HttpGet]
        [Route("SectionAdsCount/{id}")]
        public async Task<IHttpActionResult> GetSectionAdsCount(int id)
        {
            var result = await _service.GetSectionAdsCountAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("PrivateMiscAds")]
        public async Task<IHttpActionResult> GetPrivateMiscAds(SearchMiscAdsDto dto)
        {
            var result = await _service.GetMiscellaneousAdsAsync(dto);
            return Ok(result);
        }

        #endregion

        #region Business Sales

        [HttpGet]
        [Route("BusinessSaleCountries")]
        public async Task<IHttpActionResult> GetBusinessSalesCountries()
        {
            string types = ((int)ClassifiedSection.BusinessSection).ToString();

            var result = await _service.GetMiscSalesCountriesAsync(types);
            return Ok(result);
        }

        [HttpGet]
        [Route("BusiSaleCountriesByGroup/{id}")]
        public async Task<IHttpActionResult> GetMiscSalesCountryGroups(int id)
        {
            string types = ((int)ClassifiedSection.BusinessSection).ToString();

            var result = await _service.GetMiscSalesCountryGroupsAsync(id, types);
            return Ok(result);
        }

        [HttpPost]
        [Route("BusinessMiscAds")]
        public async Task<IHttpActionResult> GetBusinessMiscAds(SearchMiscAdsDto dto)
        {
            dto.SectionId = (int)ClassifiedSection.BusinessSection;
            var result = await _service.GetMiscellaneousAdsAsync(dto);
            return Ok(result);
        }

        #endregion

        #region Private and Business

        [HttpGet]
        [Route("MiscAdTypes")]
        public async Task<IHttpActionResult> GetMiscAdsTypes()
        {
            var result = await _service.GetMiscAdsTypes();
            return Ok(result);
        }

        #endregion

        #region Post Litter Ads

        [HttpPost]
        [Route("PostLitAdd")]
        public async Task<IHttpActionResult> PostLitterAds(JObject jsonData)
        {
            dynamic json = jsonData;
            JObject jAdd = json.Adds;
            JObject jLitSale = json.LitSale;

            var Add = jAdd.ToObject<SaveAddDto>();
            var Lit = jLitSale.ToObject<SavePupSaleDto>();
            
            int? result = await _service.PostLitterAdsAsync(Add,Lit);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("UpdateLitAdd")]
        public async Task<IHttpActionResult> UpdateLitterAds(JObject jsonData)
        {
            dynamic json = jsonData;
            JObject jAdd = json.Adds;
            JObject jLitSale = json.LitSale;

            var Add = jAdd.ToObject<UpdateAddDto>();
            var Lit = jLitSale.ToObject<UpdatePupSaleDto>();

            int? result = await _service.UpdateLitterAdsAsync(Add, Lit);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();
        }

        #endregion

        #region Post Dog Ads

        [HttpPost]
        [Route("PostDogAdd")]
        public async Task<IHttpActionResult> PostDogAds(JObject jsonData)
        {
            dynamic json = jsonData;
            JObject jAdd = json.Adds;
            JObject jDogSale = json.DogSale;

            var Add = jAdd.ToObject<SaveAddDto>();
            var Dog = jDogSale.ToObject<SaveDogSaleDto>();

            int? result = await _service.PostDogAdsAsync(Add, Dog);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();

        }

        [HttpPost]
        [Route("UpdateDogAdd")]
        public async Task<IHttpActionResult> UpdateDogAds(JObject jsonData)
        {
            dynamic json = jsonData;
            JObject jAdd = json.Adds;
            JObject jDogSale = json.DogSale;

            var Add = jAdd.ToObject<UpdateAddDto>();
            var Dog = jDogSale.ToObject<UpdateDogSaleDto>();

            int? result = await _service.UpdateDogAdsAsync(Add, Dog);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();
        }

        #endregion

        #region Post Misc Ads

        [HttpPost]
        [Route("PostMiscAdd")]
        public async Task<IHttpActionResult> PostMiscAds(JObject jsonData)
        {
            dynamic json = jsonData;
            JObject jAdd = json.Adds;
            JObject jMiscSale = json.MiscSale;

            var Add = jAdd.ToObject<SaveAddDto>();
            var Misc = jMiscSale.ToObject<SaveMiscAdDto>();

            int? result = await _service.PostMiscAdsAsync(Add, Misc);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("UpdateMiscAdd")]
        public async Task<IHttpActionResult> UpdateMiscAds(JObject jsonData)
        {
            dynamic json = jsonData;
            JObject jAdd = json.Adds;
            JObject jMiscSale = json.MiscSale;

            var Add = jAdd.ToObject<UpdateAddDto>();
            var Misc = jMiscSale.ToObject<UpdateMiscAdDto>();

            int? result = await _service.UpdateMiscAdsAsync(Add, Misc);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();
        }

        #endregion

        #region Delete Ads

        [HttpDelete]
        [Route("DeleteAdd")]
        public async Task<IHttpActionResult> DeleteAds(DeleteAddDto dto)
        {
            int? result = await _service.DeleteAdAsync(dto);
            if (result.HasValue)
                return Ok();
            else
                return BadRequest();
        }

        #endregion
    }
}
