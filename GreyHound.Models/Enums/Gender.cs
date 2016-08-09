using System;
using System.Runtime.Serialization;

namespace GreyHound.Models.Enums
{
    [Flags]
    public enum Gender : int
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Male = 1,
        [EnumMember]
        Female = 2
    }
}
