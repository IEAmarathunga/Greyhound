using GreyHound.Dto.Common;
using GreyHound.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Library
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }        
    }

    public class LibraryFilesDto
    {
        public int FileId { get; set; }
        public int RootId { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string DownloadPath { get; set; }
    }
    
    public class DogImagesDto
    {
        public int? CountryGroupId { get; set; }
        public int DogId { get; set; }
        public string DogName { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
        public Gender Gender { get; set; }
        public int? ColorId { get; set; }
        public string Color { get; set; }
        public DateTime? DOB { get; set; }
        public string StandingLand { get; set; }
        public string Owner { get; set; }
        public string Comment { get; set; }
        public int? AdoptId { get; set; }
        public List<ImageDto> Images { get; set; }
    }

    public class RaceVideosDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public string StadiumName { get; set; }
        public DateTime? RaceDate { get; set; }
        public string Heat { get; set; }
        public string Grade { get; set; }
        public decimal? Distance { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinTime { get; set; }
        public string Film { get; set; }
    }
}
