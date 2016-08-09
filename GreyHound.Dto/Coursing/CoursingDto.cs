using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Coursing
{
    public class CoursingDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int? CountryId { get; set; }
        public int? StadiumId { get; set; }
        public string Stadium { get; set; }
        public DateTime? RaceDate { get; set; }
        public string Grade { get; set; }
        public int? WinnerId { get; set; }
        public string WinnerName { get; set; }
        public int? SecondId { get; set; }
        public string SecondName { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }
        public string Class { get; set; }
    }

    public class CoursingSearchDto
    {
        public string CoursingName { get; set; }
        public int? CountryId { get; set; }
        public int? StadiumId { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
    }
}
