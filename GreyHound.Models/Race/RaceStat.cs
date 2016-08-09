using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GreyHound.Models.Dogs;
using GreyHound.Models.Common;

namespace GreyHound.Models.Race
{
    public class RaceStat
    {
        [Key]
        public int Stat_Id { get; set; }

        [Required()]
        [Index]
        [ForeignKey("Race")]
        public int Stat_RaceId { get; set; }

        [Index]
        [ForeignKey("Winner")]
        public int? Stat_WinnerId { get; set; }
        public int? Stat_WinnerTrap { get; set; }
        public DateTime? Stat_WinnerTime { get; set; }

        [Index]
        [ForeignKey("Second")]
        public int? Stat_SecondId { get; set; }
        public int? Stat_SecondTrap { get; set; }
        public DateTime? Stat_SecondTime { get; set; }

        [Index]
        [ForeignKey("Third")]
        public int? Stat_ThirdId { get; set; }
        public int? Stat_ThirdTrap { get; set; }
        public DateTime? Stat_ThirdTime { get; set; }

        [ForeignKey("Country")]
        [Index]
        public int? Stat_CountryId { get; set; }

        [Index]
        public int? Stat_Year { get; set; }

        [Index]
        public int? Stat_Distance { get; set; }

        [ForeignKey("Stat_RaceId")]
        public virtual Race Race { get; set; }

        [ForeignKey("Stat_WinnerId")]
        public virtual Dog Winner { get; set; }
        
        [ForeignKey("Stat_SecondId")]
        public virtual Dog Second { get; set; }

        [ForeignKey("Stat_ThirdId")]
        public virtual Dog Third { get; set; }

        [ForeignKey("Stat_CountryId")]
        public virtual Country Country { get; set; }
        

    }
}
