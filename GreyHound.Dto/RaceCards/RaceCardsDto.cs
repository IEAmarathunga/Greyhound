using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.RaceCards
{
    public class RaceCountriesDto
    {
        public int RaceCountryId { get; set; }
        public string RaceCountryName { get; set; }
    }

    public class RaceCardsDto
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }
        public DateTime? RaceDate { get; set; }
        public string Heat { get; set; }
        public string Grade { get; set; }
        public decimal? Distance { get; set; }
    }

}
