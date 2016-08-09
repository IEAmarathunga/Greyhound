using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreyHound.Models.Tracks;
using GreyHound.Models.Common;

namespace GreyHound.Models.Race
{
    public class Race
    {
        [Key]
        public int Race_Id { get; set; }

        [Required()]    
        [StringLength(50, MinimumLength = 2)]
        public string Race_Name { get; set; }
               
        //[Index]
        public DateTime? Race_DateTime { get; set; }

        //[ForeignKey("DistanceType")]
        //public int? Race_DistanceTypeId { get; set; }
        //public int? Race_Distance { get; set; }
                
        [ForeignKey("Track")]
        public int? Race_TrackId { get; set; }

        [ForeignKey("Currency")]
        public int? Race_CurrencyId { get; set; }
                
        //modelBuilder.Entity<MyClass>().Property(x => x.SnachCount).HasPrecision(10,2);
        public decimal? Race_Prize { get; set; }
        public decimal? Race_WinnerPrice { get; set; }
        public decimal? Race_SecondPrice { get; set; }
        public decimal? Race_ThirdPrice { get; set; }

        //modelBuilder.Entity<MyClass>().Property(x => x.SnachCount).HasPrecision(10,4);
        public decimal? Race_Going { get; set; }

        public int? Race_Round { get; set; }
        public string Race_Comment { get; set; }

        [ForeignKey("RaceType")]
        public int? Race_TypeId { get; set; }

        [ForeignKey("RaceGrade")]
        public int? Race_GradeId { get; set; }
        
        [StringLength(10, MinimumLength = 2)]
        public string Race_OfficialGrade { get; set; }

        [ForeignKey("RaceClass")]
        public int? Race_ClassId { get; set; }

        [ForeignKey("RaceHeat")]
        public int? Race_HeatId { get; set; }

        //[ForeignKey("Stadium")]
        //public int? Race_StadiumId { get; set; }

        [ForeignKey("RaceResultType")]
        public int? Race_ResultTypeId { get; set; }

        [ForeignKey("RaceSpecialClass")]
        public int? Race_SpecialClassId { get; set; }

        //stat related
        [ForeignKey("WinDog")]
        public int? Race_WinDogId { get; set; }
        public DateTime? Race_WinTime { get; set; }

        /*[ForeignKey("Dog")]
        public int? WinDogId { get; set; }*/                

        #region navigations

        [ForeignKey("Race_TrackId")]
        public virtual Track Track { get; set; }

        //[ForeignKey("DistanceTypeId")]
        //public virtual DistanceType DistanceType { get; set; }
        
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [ForeignKey("Race_TypeId")]
        public virtual RaceType RaceType { get; set; }

        [ForeignKey("Race_GradeId")]
        public virtual RaceGrade RaceGrade { get; set; }

        [ForeignKey("Race_ClassId")]
        public virtual RaceClass RaceClass { get; set; }

        [ForeignKey("Race_HeatId")]
        public virtual RaceHeat RaceHeat { get; set; }

        //[ForeignKey("Race_StadiumId")]
        //public virtual Tracks.Stadium Stadium { get; set; }

        [ForeignKey("Race_ResultTypeId")]
        public virtual RaceResultType RaceResultType { get; set; }

        [ForeignKey("Race_SpecialClassId")]
        public virtual RaceSpecialClass RaceSpecialClass { get; set; }

        [ForeignKey("Race_WinDogId")]
        public virtual Dogs.Dog WinDog { get; set; }

        #endregion
    }
}
