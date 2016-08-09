using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Models.Enums
{
    public enum ImageTypes
    {
        [Description("Dog Images")]
        Dog =1,
        
        LitterSale = 2,
        DogSale=3,
        MiscSale = 4,
        Stadium = 5,
    }
}
