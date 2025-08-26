using System.Runtime.Serialization;

namespace MagicBinder.Domain.Enums;

public enum Rarity
{
    [EnumMember(Value = "common")]
    Common,
    [EnumMember(Value = "uncommon")]
    Uncommon,
    [EnumMember(Value = "rare")]
    Rare,
    [EnumMember(Value = "mythic")]
    Mythic,
    [EnumMember(Value = "special")]
    Special,
    [EnumMember(Value = "bonus")]
    Bonus
}
