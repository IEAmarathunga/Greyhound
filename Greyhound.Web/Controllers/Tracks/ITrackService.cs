using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Dto.Tracks;

namespace GreyHound.Web.Controllers.Tracks
{
    public interface ITrackService
    {
        #region ADMIN BODIES

        Task<List<AdminBodyDto>> GetAdminBodiesAsync();
        Task<List<AdminBodyDto>> AdminBodiesByCountryAsync(int id);

        #endregion

        #region STADIUMS

        #region BASICS

        Task<List<StadiumDto>> GetAllStadiumsAsync();
        Task<StadiumDto> GetStadiumByIdAsync(int id);
        Task<List<StadiumsByCountryDto>> StadiumsByCountryAsync(int id);
        Task<List<StadiumImagesDto>> GetStadiumImagesAsync(int stadiumId);
        Task<List<TrackDistancesDto>> GelStadiumDistancesAsync(int stadiumId);
        Task<List<TrackDistancesDto>> GetDistanceByTracksAsync(int stadiumId);
        #endregion

        #region STATS

        Task<List<int>> GetRaceYearsAsync(int stadiumId);
        Task<List<StadiumDistancesDto>> GetTrackDistancesAsync(int stadiumId);


        Task<List<TrackRecordsDto>> GetTrackRecordsAsync(int stadiumId);
        Task<List<FastTimesDto>> GetFastTimesAsync(int stadiumId, int year, int distanceId);
        Task<List<TrapStatsDto>> GetTrapStatsAsync(int stadiumId, int year, int? distanceId);
        Task<List<DistanceWiseRacesDto>> GetYearAndDistanceWiseStatAsync(int stadiumId);
        Task<List<AvgAndBestTimeDto>> GetAvgAndBestAsync(int stadiumId, int? year, int? quarter, int? distanceId);
        
        #endregion

        #endregion

        #region TRACKS
        Task<List<TrackCountryDto>> GetAllTrackCountriesAsync();
        Task<List<TrackCountryDto>> GetTrackByCountryIdAsync(int countryId);

        Task<List<TrackDto>> TracksByStadiumAsync(int id);
        Task<List<TrackFormsDto>> TrackFormsByStadiumIdAsync(int stadiumId);

        #endregion

        #region Post Tracks

        Task<bool> PostTrackFormsAsync(List<SaveTrackFormsDto> dto);
        Task<bool> DeleteTrackFormsAsync(DeleteTrackFormDto dto);

        #endregion
    }
}
