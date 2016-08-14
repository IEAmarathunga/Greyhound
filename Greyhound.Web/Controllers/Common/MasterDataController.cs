using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GreyHound.WebApplication.Controllers.Common
{
    [RoutePrefix("api/masterData")]
    public class MasterDataController : ApiController
    {
        private readonly IMasterDataService _service;

        public MasterDataController()
        {
            _service = new MasterDataService();
        }

        public MasterDataController(IMasterDataService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("DogColors")]
        public async Task<IHttpActionResult> GetDogColors()
        {
            try
            {
                var result = await _service.GetDogColorsAsync();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Currency")]
        public async Task<IHttpActionResult> GetCurrencies()
        {
            try
            {
                var result = await _service.GetCurrenciesAsync();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //[Route("ColorCategories")]
        //public async Task<IHttpActionResult> GetColorCategories()
        //{
        //    try
        //    {
        //        var result = await _service.GetColorCategoriessAsync();
        //        return Ok(result);
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}
        
        //[HttpGet]
        //[Route("Lands")]
        //public async Task<IHttpActionResult> GetLands()
        //{
        //    var result = await _service.GetLandsAsync();
        //    return Ok(result);
        //}

        [HttpGet]
        [Route("Breeds")]
        public async Task<IHttpActionResult> GetBreeds()
        {
            var result = await _service.GetBreedsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("AgeGroup")]
        public async Task<IHttpActionResult> GetAgeGroups()
        {
            var result = await _service.GetAgeGroupsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Countries")]
        public async Task<IHttpActionResult> GetCountries()
        {
            var result = await _service.GetCountriesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("CountryGroups")]
        public async Task<IHttpActionResult> GetCountryGroups()
        {
            var result = await _service.GetCountryGroupsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Country/{id}")]
        public async Task<IHttpActionResult> GetCountryById(int id)
        {
            var result = await _service.GetCountryByIdAsync(id);
            return Ok(result);
        }
        
        //[HttpGet]
        //[Route("MemberTypes")]
        //public IHttpActionResult GetMemberTypes()
        //{
        //    var result = _service.GetMemberTypes();
        //    return Ok(result);
        //}

        [HttpGet]
        [Route("MemberTypes")]
        public async Task<IHttpActionResult> GetMemberTypes()
        {
            var result = await _service.GetMemberTypes();
            return Ok(result);
        }

        [HttpGet]
        [Route("Months")]
        public IHttpActionResult GetMonths()
        {
            var result = _service.GetMonths();
            return Ok(result);
        }
       
    }
}
