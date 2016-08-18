using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Tracks
{
    public class TrackCountryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TrackDto
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public string Stadium { get; set; }
        public decimal? Distance { get; set; }
        public DateTime? QualifyingTime { get; set; }
        public bool Hurdles { get; set; }
        public bool IsActive { get; set; }        
    }

    public class TrackRecordDto
    {
        public int? OwnerId { get; set; }
        public string OwnerName { get; set; }
        public DateTime? RecordTime { get; set; }
        public DateTime? RecordDate { get; set; }
    }

    public class TrackFormsDto
    {
        public int? FormId { get; set; }
        public int? TrackId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal? Time { get; set; }
    }

    public class TrackRecordsDto
    {
        public int RaceId { get; set; }
        public DateTime? RaceDate { get; set; }
        public decimal? Distance { get; set; }
        public string RaceType { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinnerTime { get; set; }
    }

    public class SaveTrackFormsDto
    {
        public int? TFormId { get; set; }
        public int TrackId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal? Time { get; set; }
    }

    public class TrackDistancesDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
    }

    public class DeleteTrackFormDto
    {
        public int TrackFormId { get; set; }
        public int DeletedBy { get; set; }
        public string Comment { get; set; }
    }
}
