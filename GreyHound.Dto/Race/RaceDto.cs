using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Dto.Tracks;
using GreyHound.Dto.Dogs;
using GreyHound.Models.Enums;

namespace GreyHound.Dto.Race
{
    public class SearchRacesDto
    {
        public string RaceName { get; set; }
        public int? CountryId { get; set; }
        public int? StadiumId { get; set; }
        public int? ClassId { get; set; }
        public decimal? DistanceFrom { get; set; }
        public decimal? DistanceTo { get; set; }
        public DateTime RaceDateFrom { get; set; }
        public DateTime RaceDateTo { get; set; }
    }

    public class RaceSearchResultDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int? CountryId { get; set; }
        
        public int? StadiumId { get; set; }
        public string Stadium { get; set; }
        
        public DateTime? DateTime { get; set; }        
        public string Heat { get; set; }        
        public string Grade { get; set; }
        
        public decimal? Distance { get; set; }
        public int? WinDogId { get; set; }
        public string WinDogName { get; set; }
        
        public DateTime? WinTime { get; set; }
        public decimal? Price { get; set; }
        
        public int? ClassId { get; set; }
        public string Class { get; set; }

        public string Film { get; set; }
        
    }

    public class RaceInDetailDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }        
        public string Country { get; set; }

        public int? StadiumId { get; set; }
        public string Stadium { get; set; }
        
        public DateTime? DateTime { get; set; }        
        public string Heat { get; set; }
        public decimal? Distance { get; set; }
        public string RaceType { get; set; }
        public string Grade { get; set; }

        public string CurrencySymbol { get; set; }
        public decimal? WinnerPrice { get; set; }
        public decimal? SecondPrice { get; set; }
        public decimal? ThirdPrice { get; set; }

        public string Comment { get; set; }

        public TrackRecordDto TrackRecord { get; set; }
        public TrackRecordDto YearRecord { get; set; }
        public TrackRecordDto LastQuarterRecord { get; set; }
        public TrackRecordDto ThisQuarterRecord { get; set; }
        public IList<RaceRunnersDto> RaceResult { get; set; }
    }

    public class RaceRunnersDto
    {
        public string FinishedOrder { get; set; }
        public int? DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? DamSireId { get; set; }
        public string Color { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? DOB { get; set; }
        public IList<RaceRunnerDto> Runner { get; set; }
        public DateTime? Time { get; set; }
        public string DistanceToWinner { get; set; }
        public DateTime? STime { get; set; }
        public int? Trap { get; set; }
        public int? Position { get; set; }
        public decimal? StartPrice { get; set; }
        public string CurrencySymbol { get; set; }
        public string Comment { get; set; }
    }

    public class RaceByDogDto
    {
        public int RaceId { get; set; }
        public DateTime? RaceDate { get; set; }
        public int? StadiumId { get; set; }
        public string StadiumName { get; set; }
        public string Distance { get; set; }
        public string RaceGrade { get; set; }
        public int? NoOfDogs { get; set; }
        public string Trap { get; set; }
        public DateTime? STime { get; set; }
        public string Position { get; set; }
        public string FinishOrder { get; set; }
        public string Comment { get; set; }
        public decimal? Points { get; set; }
        public decimal? StartPrice { get; set; }
        public decimal? Weight { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public DateTime? EstimatedTime { get; set; }
        public int? Form { get; set; }
        public string Film { get; set; }
    }
}
