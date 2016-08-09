using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Race
{
    public class RaceClassDto
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceDistanceToWinnerTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceDistanceTypeDto
    {
        public int Id { get; set; }
        public string Distance { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceFinishedOrderDto
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceGradeDto
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceResultTypeDto
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceSpecialClassTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class RaceTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
