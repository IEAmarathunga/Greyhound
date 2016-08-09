using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyHound.Models.Enums;

namespace GreyHound.Dto.Dogs
{
    public class TattooDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LeftEar { get; set; }
        public string RightEar { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? ColorCategoryId { get; set; }
        public int? ColorId { get; set; }
        public string Color { get; set; }
        public int? LandId { get; set; }
        public string Land { get; set; }
        public DateTime? DOB { get; set; }
        public Gender Gender { get; set; }
        public string IsActive { get; set; }
    }

    public class TattooSearchDto
    {
        public int? Gender { get; set; }
        public int? ColorId { get; set; }
        public int? Year { get; set; }
        public int? LandId { get; set; }
        public string LeftEar { get; set; }
        public string RightEar { get; set; }                      
    }
}
