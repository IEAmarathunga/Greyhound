using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Race
{    
    public class RaceResult
    {
        [Key]
        public int result_Id { get; set; }
        
        [ForeignKey("Race")]
        public int result_RaceId { get; set; }

        [ForeignKey("Dog")]
        public int result_DogId { get; set; }

        [ForeignKey("RaceFinishedOrder")]
        public int result_FinishedOrderId { get; set; }

        public int? result_Trap { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? result_Time { get; set; }
        
        [ForeignKey("DistanceToWinner")]
        public int? result_DistanceToWinnerId { get; set; }

       [Column(TypeName = "DateTime2")]
        public DateTime? result_FirstCrossTime { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? result_EstimatedTime { get; set; }

        //modelBuilder.Entity<MyClass>().Property(x => x.SnachCount).HasPrecision(5,2);
        public decimal? result_DogRaceWeight { get; set; }

        public int? result_Position { get; set; }

        public int? result_Form { get; set; }
        public decimal? result_Points { get; set; }

        //modelBuilder.Entity<MyClass>().Property(x => x.SnachCount).HasPrecision(10,2);
        public decimal? result_DogOdds { get; set; }

        public string result_Comment { get; set; }


        #region navigation

        [ForeignKey("result_RaceId")]
        public virtual Race Race { get; set; }

        [ForeignKey("result_DogId")]
        public virtual Dogs.Dog Dog { get; set; }

        [ForeignKey("result_FinishedOrderId")]
        public virtual RaceFinishedOrder RaceFinishedOrder { get; set; }

        [ForeignKey("result_DistanceToWinnerId")]
        public virtual DistanceToWinner DistanceToWinner { get; set; }

        #endregion
    }
}
