using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Enums
{
    public enum SireCondition : int
    {
        [Description("in 5 generations")]
        fiveGen = 1,

        [Description("in 5 gen sire line")]
        fiveGen_SireLine = 2,

        [Description("in 5 gen dam line")]
        fiveGen_DamLine = 3,

        [Description("in 5 gen through a son")]
        fiveGen_ThroughSon = 4,

        [Description("in 5 gen through a daughter")]
        fiveGen_ThroughDaughter = 5,

        [Description("3rd or 4th generations")]
        thirdOrFourthGen = 6,

        [Description("duplicated")]
        duplicated = 7,

        [Description("cross duplicated")]
        crossDuplicated = 8,

        [Description("sex-balanced")]
        sexBalanced = 9,

        [Description("not-present")]
        notPresent = 10,
    }

    public enum SearchMode : int
    {
        Easy = 1,
        Expert = 2
    }
}
