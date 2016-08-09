using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Enums
{
    [Flags]
    public enum RaceFinishOrder : int
    {
        winner = 1,
        second= 2,
        thrid =3,
        fourth =4,
        fifth =5,
        sixth =6,
        seventh=7,
        eighth=8,
        ninth =9
    }
}
