using GreyHound.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Race
{
    public class WonStatDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public DateTime? RaceDate { get; set; }
        public int? StadiumId { get; set; }
        public string StadiumName { get; set; }
        public string Grade { get; set; }
        public string Distance { get; set; }
        public DateTime? Time { get; set; }
        public int? Box { get; set; }
        public string Comment { get; set; }
    }

    public class RaceCountYearWiseDto
    {
        public int Year { get; set; }
        public int? RaceCount { get; set; }
    }

    public class DistanceBehaviorDto
    {
        public int Year { get; set; }
        public int DogId { get; set; }
        public int DistanceId { get; set; }
        public string Distance { get; set; }
        public int? RaceCount { get; set; }
        public int? First { get; set; }
        public int? Second { get; set; }
        public int? Third { get; set; }
        public int? Fourth { get; set; }
        public int? Fifth { get; set; }
        public int? Sixth { get; set; }
        public string Average { get; set; }
        public string Fastest { get; set; }
        public int? FastestRaceId { get; set; }
        public DateTime? FastestRaceName { get; set; }
        public int? Form { get; set; }
    }

    public class SearchByStatDto
    {
        public int DogId { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public int? DistanceId { get; set; }
    }

    public class ResultForSearchByStatDto
    {
        public int RaceId { get; set; }
        public DateTime? RaceDate { get; set; }
        public int? StadiumId { get; set; }
        public string StadiumName { get; set; }
        public int? DistanceId { get; set; }
        public decimal? Distance { get; set; }
        public string Grade { get; set; }
        public int? Dogs { get; set; }
        public int? Trap { get; set; }
        public DateTime? Stime { get; set; }
        public int? Position { get; set; }
        public string FinishOrder { get; set; }
        public string Comment { get; set; }
        public decimal? Points { get; set; }
        public decimal? SP { get; set; }
        public decimal? DogRaceWeight { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinTime { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? ETime { get; set; }
        public int? Form { get; set; }
        public string Film { get; set; }
    }

    public class RaeComaprisonDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public DateTime? RaceDate { get; set; }
        public int? TrackId { get; set; }
        public int? StadiumId { get; set; }
        public string StadiumName { get; set; }
        public string Grade { get; set; }
        public int? DistanceId { get; set; }
        public string Distance { get; set; }
        public string FinishOrder { get; set; }
        public DateTime? FinishTime { get; set; }
        public decimal? DWT { get; set; }
        public decimal? DT { get; set; }
        public DateTime? STime { get; set; }
        public int? Box { get; set; }
        public int? Position { get; set; }
        public decimal? SP { get; set; }
        public decimal? DogRaceWeight { get; set; }
        public string Comment { get; set; }
        public decimal? Points { get; set; }
        public int? Form { get; set; }
    }

    public class RaceResultDto
    {
        public string FinishOrder { get; set; }
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Color { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
        public decimal? FinishTime { get; set; }
        public string DistanceToWinner { get; set; }
        public decimal? STime { get; set; }
        public int? Box { get; set; }
        public int? Position { get; set; }
        public decimal? SP { get; set; }
        public decimal? Weight { get; set; }
        public string Comment { get; set; }
    }

    public class RaceHistoryDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string Film { get; set; }
        public int? StadiumId { get; set; }
        public string StadiumName { get; set; }
        public int? TrackCountryId { get; set; }
        public string TrackCountryName { get; set; }
        public DateTime? RaceDate { get; set; }
        public string RaceHeat { get; set; }
        public string RaceType { get; set; }
        public string RaceClass { get; set; }
        public string RaceLength { get; set; }
        public string Currency { get; set; }
        public decimal? WinnerPrice { get; set; }
        public List<RaceResultDto> Result { get; set; }
    }

    public class DWTStatDto
    {
        public int RaceId { get; set; }
        public DateTime RaceDate { get; set; }
        public int DogId { get; set; }
        public int TrackId { get; set; }
        public decimal? DWT { get; set; }
    }

    public class DTStatDto
    {
        public int RaceId { get; set; }
        public DateTime RaceDate { get; set; }
        public int DogId { get; set; }
        public int TrackId { get; set; }
        public decimal? DWT { get; set; }
    }

    public class OffspringRaceStatDto
    {
        public int DogId { get; set; }
        public int TopRaces { get; set; }
        public int First { get; set; }
        public int Second { get; set; }
    }

    #region Advance Statistics

    public class RaceStatTypesDto
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class SimpleRaceStatDto
    {
        public int StatTypeId { get; set; }
        public int CountryId { get; set; }
        public int RaceYearId { get; set; }
        public int? DistanceFrom { get; set; }
        public int? DistanceTo { get; set; }
    }

    public class TimeBasedStatDto
    {
        public int StatTypeId { get; set; }
        public int CountryId { get; set; }
        public int DistanceId { get; set; }
        public int RaceYearId { get; set; }
    }

    public class AdvanceStatDto
    {
        public int StatTypeId { get; set; }
        public int CountryId { get; set; }
        public int RaceYearId { get; set; }
        public int? DistanceFrom { get; set; }
        public int? DistanceTo { get; set; }
    }

    public class SimpleStatResultDto
    {
        public int? DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
        public int? Wins { get; set; }
        public int? Races { get; set; }
        public string WinPercentage { get; set; }
        public int? First { get; set; }
        public int? Second { get; set; }
        public int? Third { get; set; }
        public int? WinDistance { get; set; }
    }

    public class TimeBasedStatResultDto
    {
        public DateTime? Time { get; set; }
        public int RaceId { get; set; }
        public DateTime? RaceDate { get; set; }
        public int? CountryId { get; set; }
        public int? StadiumId { get; set; }
        public string StadiumName { get; set; }
        public int? DistanceId { get; set; }
        public decimal? Distance { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public Gender Gender { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
    }

    public class AdvanceStatResultDto
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
        public int? Races { get; set; }
        public decimal? Points { get; set; }
        public int? AvgDistance { get; set; }
    }

    #endregion
}
