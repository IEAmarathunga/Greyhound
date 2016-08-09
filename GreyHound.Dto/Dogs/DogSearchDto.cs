using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Models.Enums;

namespace GreyHound.Dto.Dogs
{
    public class DogSearchDto
    {
        public string Name { get; set; }
        public int? ColorId { get; set; }
        public int? LandId { get; set; }
        public int? BreedId { get; set; }
        public int? Gender { get; set; }
        public int? Year { get; set; }
    }

    public class ExistingDogsDto
    {
        public int DogId { get; set; }
        public string DogName { get; set; }
        public DateTime? DOB { get; set; }
        public Gender Gender { get; set; }
        public string BirthLand { get; set; }
        public string Color { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
    }
   
}
