using GreyHound.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Sire
{
    public class OffspringDto
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Land { get; set; }
        public string Color { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? DamSireId { get; set; }
        public string DamSireName { get; set; }
        public int? Offspring { get; set; }
        public int? Races { get; set; }
        public int? Wins { get; set; }
        public int? secondPlaces { get; set; }
        public string bGrade { get; set; }
        public int? bForm { get; set; }
    }

    public class TopOffspringDto
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Land { get; set; }
        public string Color { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? DamSireId { get; set; }
        public string DamSireName { get; set; }
        public int? TopRaces { get; set; }
        public int? First { get; set; }
        public int? Second { get; set; }
        public decimal? Points { get; set; }
    }

    public class SecondOffspringDto
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Land { get; set; }
        public string Color { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? DamSireId { get; set; }
        public string DamSireName { get; set; }
        public int? Offspring { get; set; }
        public int? Races { get; set; }
        public int? Wins { get; set; }
        public int? secondPlaces { get; set; }
        public string bGrade { get; set; }
        public int? bForm { get; set; }
    }

    public class TopSecondOffspringDto
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Land { get; set; }
        public string Color { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? DamSireId { get; set; }
        public string DamSireName { get; set; }
        public int? TopRaces { get; set; }
        public int? First { get; set; }
        public int? Second { get; set; }
        public decimal? Points { get; set; }
    }
}
