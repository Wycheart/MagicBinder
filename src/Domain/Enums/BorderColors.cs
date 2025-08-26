using System.Runtime.Serialization;

namespace MagicBinder.Domain.Enums;

public enum BorderColors
{
    [EnumMember(Value = "black")]
    Black,
    [EnumMember(Value = "borderless")]
    Borderless,
    [EnumMember(Value = "gold")]
    Gold,
    [EnumMember(Value = "silver")]
    Silver,
    [EnumMember(Value = "white")]
    White,
    [EnumMember(Value = "yellow")]
    Yellow
}
