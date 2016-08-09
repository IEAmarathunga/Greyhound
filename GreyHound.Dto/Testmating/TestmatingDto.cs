using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Models.Enums;

namespace GreyHound.Dto.Testmating
{

    public class SearchDto
    {
        public SearchMode Mode { get; set; }
        
        public int? SireId { get; set; }
        public int? DamId { get; set; }

        public int? SireSireId { get; set; }
        public int? SireDamId { get; set; }
        public int? DamSireId { get; set; }
        public int? DamDamId { get; set; }
    }

    public class SireCountriesDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class SireDto
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
    }

    public class DamDto
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
    }
}
