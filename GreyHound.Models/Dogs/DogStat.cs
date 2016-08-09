using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GreyHound.Models.Race;

namespace GreyHound.Models.Dogs
{
    public class DogStat
    {
        [Key]
        public int DogStat_Id { get; set; }

        [ForeignKey("Dog")]
        [Index(IsUnique=true)]
        public int DogStat_DogId { get; set; }

        [Index]
        public int? DogStat_RaceCount { get; set; }
        [Index]
        public int? DogStat_WinCount { get; set; }
        [Index]
        public int? DogStat_SecondPlaceCount { get; set; }

        [Index]
        public int? DogStat_TopRaces { get; set; }
        [Index]
        public int? DogStat_TopRacesWins { get; set; }
        [Index]
        public int? DogStat_TopRacesSecond { get; set; }

        [Index]
        public int? DogStat_Offspring { get; set; }
        [Index]
        public decimal? DogStat_Points { get; set; }

        [ForeignKey("BestGrade")]
        public int? DogStat_BestGradeId { get; set; }

        [Index]
        public int? DogStat_BestForm { get; set; }

        # region navigation properties

        [ForeignKey("DogStat_DogId")]
        public virtual Dog Dog { get; set; }

        [ForeignKey("Dog_BestGradeId")]
        public virtual RaceGrade BestGrade { get; set; }

        #endregion
    }
}
