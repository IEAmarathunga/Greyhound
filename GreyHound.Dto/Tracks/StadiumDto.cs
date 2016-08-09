using GreyHound.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Tracks
{
    public class StadiumOpenDays
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    public class StadiumDto
    {   
        public int Id { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        public List<StadiumOpenDays> DaysOpen { get; set; }        
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }       
    }

    public class StadiumImagesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class StadiumsByCountryDto
    {
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
    }
    

    #region STADIUM STATS

    public class StadiumDistancesDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
    }

    

    public class FastTimesDto
    {
        public int RaceId { get; set; }
        public DateTime? RaceDate { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinnerTime { get; set; }
        public Gender Gender { get; set; }
        public string Sire { get; set; }
        public string Dam { get; set; }
        public decimal? Points { get; set; }
    }

    public class TrapStatsDto
    {
        public int FinOrder { get; set; }
        public int? RaceCount { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
    }

    public class DistanceWiseRacesDto
    {
        public int Year { get; set; }
        public string Distance { get; set; }
        public int RaceCount { get; set; }
    }

    public class AvgAndBestTimeDto
    {
        public decimal Distance { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int DifRunners { get; set; }
        public double AvgTime { get; set; }
        public double AvgWinTime { get; set; }
        public DateTime? BestTime { get; set; }
        public int BestRunnerId { get; set; }
        public string BestRunnerName { get; set; }
        public int BestRaceId { get; set; }
        public DateTime? BestRaceDate { get; set; }
    }

    #endregion
}
