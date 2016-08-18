using GreyHound.Dto.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GreyHound.Web.Controllers.Tracks
{
    [RoutePrefix("api/Track")]
    public class TrackController : ApiController
    {
        private readonly ITrackService _service;

        public TrackController()
        {
            _service = new TrackService();
        }

        public TrackController(ITrackService service)
        {
            _service = service;
        }

        #region Administration Body

        [HttpGet]
        [Route("AdminBodies")]
        public async Task<IHttpActionResult> AdminBodies()
        {
            var result = await _service.GetAdminBodiesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("AdminBodiesByCountry/{id}")]
        public async Task<IHttpActionResult> AdminBodiesByCountryId(int id)
        {
            var result = await _service.AdminBodiesByCountryAsync(id);
            return Ok(result);
        }

        #endregion

        #region Stadium

        #region BASICS

        [HttpGet]
        [Route("Stadiums")]
        public async Task<IHttpActionResult> GelAllStadiums()
        {
            var result = await _service.GetAllStadiumsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Stadium/{id}")]
        public async Task<IHttpActionResult> GelStadiumById(int id)
        {
            var result = await _service.GetStadiumByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("StadiumsByCountry/{id}")]
        public async Task<IHttpActionResult> StadiumsByCountryId(int id)
        {
            var result = await _service.StadiumsByCountryAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("StadiumImages/{stadiumId}")]
        public async Task<IHttpActionResult> GelStadiumImages(int stadiumId)
        {
            var result = await _service.GetStadiumImagesAsync(stadiumId);
            return Ok(result);
        }

        [HttpGet]
        [Route("StadiumDistances/{stadiumId}")]
        public async Task<IHttpActionResult> GelStadiumDistances(int stadiumId)
        {
            var result = await _service.GelStadiumDistancesAsync(stadiumId);
            return Ok(result);
        }

        [HttpGet]
        [Route("DistanceByTracks/{stadiumId}")]
        public async Task<IHttpActionResult> GetDistanceByTracks(int stadiumId)
        {
            var result = await _service.GetDistanceByTracksAsync(stadiumId);
            return Ok(result);
        }

        #endregion

        #region STATS

        [HttpGet]
        [Route("RaceYears/{stadiumId}")]
        public async Task<IHttpActionResult> GetRaceYears(int stadiumId)
        {
            var result = await _service.GetRaceYearsAsync(stadiumId); // get year as list of ints
            return Ok(result);
        }

        [HttpGet]
        [Route("TrackDistances/{stadiumId}")]
        public async Task<IHttpActionResult> GetTrackDistances(int stadiumId)
        {
            var result = await _service.GetTrackDistancesAsync(stadiumId); // get distances as dictioneries
            return Ok(result);
        }

        [HttpGet]
        [Route("TrackRecords/{stadiumId}")]
        public async Task<IHttpActionResult> GetTrackRecords(int stadiumId)
        {
            var result = await _service.GetTrackRecordsAsync(stadiumId);
            return Ok(result);
        }

        [HttpGet]
        [Route("FastTimes/{stadiumId}/{year}/{distanceId}")]
        public async Task<IHttpActionResult> GetFastTimes(int stadiumId, int year, int distanceId)
        {
            var result = await _service.GetFastTimesAsync(stadiumId, year, distanceId);
            return Ok(result);
        }

        [HttpGet]
        [Route("TrapStats/{stadiumId}/{year}/{distanceId}")]
        public async Task<IHttpActionResult> GetTrapStats(int stadiumId, int year, int? distanceId)
        {
            var result = await _service.GetTrapStatsAsync(stadiumId, year, distanceId);
            return Ok(result);
        }

        [HttpGet]
        [Route("YearAndDistanceWise/{stadiumId}")]
        public async Task<IHttpActionResult> GetYearAndDistanceWiseStat(int stadiumId)
        {
            var result = await _service.GetYearAndDistanceWiseStatAsync(stadiumId);
            return Ok(result);
        }
       
        [HttpGet]
        [Route("AvgAndBest/{stadiumId}/{year}/{quarter}/{distanceId}")]
        public async Task<IHttpActionResult> GetAvgAndBest(int stadiumId, int? year, int? quarter, int? distanceId)
        {
            var result = await _service.GetAvgAndBestAsync(stadiumId, year,quarter, distanceId);
            return Ok(result);
        }

        #endregion

        #endregion

        #region Track

        [HttpGet]
        [Route("Countries")]
        public async Task<IHttpActionResult> GetAllTrackCountries()
        {
            var result = await _service.GetAllTrackCountriesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("Country/{id}")]
        public async Task<IHttpActionResult> GetTrackByCountryId(int id)
        {
            var result = await _service.GetTrackByCountryIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("Track/{id}")]
        public async Task<IHttpActionResult> TracksByStadiumId(int id)
        {
            var result = await _service.TracksByStadiumAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("TrackForm/{id}")]
        public async Task<IHttpActionResult> TrackFormsByStadiumId(int id)
        {
            var result = await _service.TrackFormsByStadiumIdAsync(id);
            return Ok(result);
        }

        #endregion

        #region Post Tracks
        //insert or update track form
        [HttpPost]
        [Route("PostTrackForm")]
        public async Task<IHttpActionResult> PostTrackForm(List<SaveTrackFormsDto> dto)
        {
            bool result = await _service.PostTrackFormsAsync(dto);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteTrackForm")]
        public async Task<IHttpActionResult> DeleteTrackForm(DeleteTrackFormDto dto)
        {
            bool result = await _service.DeleteTrackFormsAsync(dto);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        #endregion
    }
}
