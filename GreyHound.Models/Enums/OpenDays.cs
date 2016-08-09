using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Enums
{
    public enum OpenDays : int
    {
        [Description("Monday Afternoon")]
        Aft_Monday = 1,
        [Description("Tuesday Afternoon")]
        Aft_Tuesday = 2,
        [Description("Wednesday Afternoon")]
        Aft_Wednesday = 3,
        [Description("Thursday Afternoon")]
        Aft_Thursday = 4,
        [Description("Friday Afternoon")]
        Aft_Friday = 5,
        [Description("Saturday Afternoon")]
        Aft_Saturday = 6,
        [Description("Sunday Afternoon")]
        Aft_Sunday = 7,

        [Description("Monday Evening")]
        Eve_Monday = 8,
        [Description("Tuesday Evening")]
        Eve_Tuesday = 9,
        [Description("Wednesday Evening")]
        Eve_Wednesday = 10,
        [Description("Thursday Evening")]
        Eve_Thursday = 11,
        [Description("Friday Evening")]
        Eve_Friday = 12,
        [Description("Saturday Evening")]
        Eve_Saturday = 13,
        [Description("Sunday Evening")]
        Eve_Sunday = 14,

    }
}
