using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Race
{
    public class BestGradeDto
    {
        public int DogId { get; set; }
        public string BestGrade { get; set; }
    }

    public class RacesStatDto
    {
        public int DogId { get; set; }
        public int? Races { get; set; }
        public int? Wins { get; set; }
        public int? Second { get; set; }
    }

    public class OffspringCountDto
    {
        public int DogId { get; set; }
        public int? Offspring { get; set; }
    }

    public class BestFormDto
    {
        public int DogId { get; set; }
        public int? BForm { get; set; }
    }

    public class RaceWinnerDto
    {
        public int RaceId { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }
        public DateTime? WinTime { get; set; }
    }

    public class NumberOfRunnersDto
    {
        public int RaceId { get; set; }
        public int? Runners { get; set; }
    }

    public class PointsDto
    {
        public int DogId { get; set; }
        public decimal? Points { get; set; }
    }


}
