using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Models.Enums;
namespace GreyHound.Dto.Dogs
{
    public class DogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? DamSireId { get; set; }
        public string DamSireName { get; set; }
        //public int? ColorCategoryId { get; set; }
        //public string ColorCategory { get; set; }
        public int? ColorId { get; set; }
        public string Color { get; set; }
        public int? LandId { get; set; }
        public string Land { get; set; }
        public int? BreedId { get; set; }
        public string Breed { get; set; }
        public DateTime? DOB { get; set; }
        public Gender Gender { get; set; }
        public decimal? Weight { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceRunnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public decimal? Weight { get; set; }
    }

    public class SireDto
    {
        public int SireId { get; set; }
        public string SireName { get; set; }
    }

    public class DogImagesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class OffspringStatDto
    {
        public int? Offspring { get; set; }
        public int? TopOffspring { get; set; }
        public double? Percentage { get; set; }
        public decimal? TotalPoints { get; set; }
    }
}
