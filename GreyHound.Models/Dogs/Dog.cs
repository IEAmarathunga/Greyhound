using GreyHound.Models.Common;
using GreyHound.Models.Race;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Dogs
{
    public class Dog
    {
        public Dog()
        {
            Dog_IsLock = false;
        }

        [Key]
        public int Dog_Id { get; set; }

        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string Dog_Name { get; set; }

        [ForeignKey("Sire")]
        public int? Dog_SireId { get; set; }

        [ForeignKey("Dam")]
        public int? Dog_DamId { get; set; }
        
        public DateTime? Dog_DateOfBirth { get; set; }

        [ForeignKey("BirthLand")]
        public int? Dog_BirthLandId { get; set; }

        [ForeignKey("StandingLand")]
        public int? Dog_StandinglandId { get; set; }

        public int? Dog_Gender { get; set; }
                
        [ForeignKey("Breed")]
        public int? Dog_BreedId { get; set; }

        [ForeignKey("DogColor")]
        public int? Dog_ColorId { get; set; }
        
        [StringLength(30, MinimumLength = 2)]
        public string Dog_TattooR { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string Dog_TattooL { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Index(IsUnique = true)]
        public string Dog_ChipNo { get; set; }
        
        public decimal? Dog_Weight { get; set; }

        public bool Dog_IsActiveSire { get; set; }
        public bool Dog_Deceased { get; set; }
        public bool Dog_IsLock { get; set; }

        [StringLength(500)]
        public string Dog_Comment { get; set; }

        //DOG STAT RELATED COLUMNS
        public int? Dog_NoOfRaces { get; set; }        
        public int? Dog_WinCount { get; set; }
        public int? Dog_SecondPlaceCount { get; set; }

        public int? Dog_NoOfTopRaces { get; set; }
        public int? Dog_TopRacesWins { get; set; }
        public int? Dog_TopRacesSecond { get; set; }

        public int? Dog_OffspringCount { get; set; }
        public decimal? Dog_Points { get; set; }

        [ForeignKey("BestGrade")]
        public int? Dog_BestGradeId { get; set; }
        
        public int? Dog_BestForm { get; set; }

        # region navigation properties

        [ForeignKey("Dog_SireId")]
        public virtual Dog Sire { get; set; }

        [ForeignKey("Dog_DamId")]
        public virtual Dog Dam { get; set; }

        [InverseProperty("Sire")]
        public virtual ICollection<Dog> DogsSires { get; set; }
        [InverseProperty("Dam")]
        public virtual ICollection<Dog> DogsDams { get; set; }


        [ForeignKey("Dog_BreedId")]
        public virtual Breed Breed { get; set; }

        [ForeignKey("Dog_ColorId")]
        public virtual DogColor DogColor { get; set; }

        [ForeignKey("Dog_BirthLandId")]
        public virtual Country BirthLand { get; set; }

        [ForeignKey("Dog_StandingLandId")]
        public virtual Country StandingLand { get; set; }
       
        [ForeignKey("Dog_BestGradeId")]
        public virtual RaceGrade BestGrade { get; set; }
           
        #endregion

    }
}
