using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Sire
{
    public class ActiveSireDto
    {        
        public int DogId { get; set; }
        public string DogName { get; set; }
        public DateTime? DOB { get; set; }
        public string BLand { get; set; }
        public string SLand { get; set; }
        public string Color { get; set; }
        public int? SireId { get; set; }
        public string SireName { get; set; }
        public int? DamId { get; set; }
        public string DamName { get; set; }
        public int? Offspring { get; set; }
        public int? SirePageId { get; set; }
    }


}
