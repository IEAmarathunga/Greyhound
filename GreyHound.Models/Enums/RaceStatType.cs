using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Enums
{    
    public enum AdvanceRaceStat : int
    {
        [Description("Top Dogs")]
        TopDogs = 1,

        [Description("Top Sires")]
        TopSires = 2,

        [Description("Top Dams")]
        TopDams = 3,

        [Description("Top SireSires")]
        TopSireSires = 4,

        [Description("Top SireDams")]
        TopSireDams = 5,

        [Description("Top DamSires")]
        TopDamSires = 6,

        [Description("Top DamDams")]
        TopDamDams = 7,
    }

    public enum SimpleRaceStat : int
    {
        [Description("Dog with most race wins")]
        DogWins = 1,

        [Description("Sire with most race wins")]
        SireWins = 2,
    }

    public enum TimeBasedRaceStat : int
    {
        [Description("The fastest races of the main race distance")]
        FastestByMainDistance = 1
    }
   
}
