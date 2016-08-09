using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Enums
{
    [Flags]
    public enum ClassifiedSection : int
    {
        [Description("Private For Sale")]
        PrivateSale = 1,

        [Description("Private Wanted")]
        PrivateWanted =2,

        [Description("Business Ad Section")]
        BusinessSection=3
    }
}
