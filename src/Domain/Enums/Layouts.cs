using System.Runtime.Serialization;

namespace MagicBinder.Domain.Enums;

public enum Layouts
{
    [EnumMember(Value = "normal")]
    Normal,
    [EnumMember(Value = "split")]
    Split,
    [EnumMember(Value = "flip")]
    Flip,
    [EnumMember(Value = "transform")]
    Transform,
    [EnumMember(Value = "meld")]
    Meld,
    [EnumMember(Value = "leveler")]
    Leveler,
    [EnumMember(Value = "saga")]
    Saga,
    [EnumMember(Value = "planar")]
    Planar,
    [EnumMember(Value = "scheme")]
    Scheme,
    [EnumMember(Value = "vanguard")]
    Vanguard,
    [EnumMember(Value = "token")]
    Token,
    [EnumMember(Value = "double_faced_token")]
    DoubleFacedToken,
    [EnumMember(Value = "emblem")]
    Emblem,
    [EnumMember(Value = "augment")]
    Augment,
    [EnumMember(Value = "host")]
    Host,
    [EnumMember(Value = "adventure")]
    Adventure,
    [EnumMember(Value = "art_series")]
    Art_series,
    [EnumMember(Value = "special")]
    Special,
    [EnumMember(Value = "mutate")]
    Mutate,
    [EnumMember(Value = "modal_dfc")]
    Modal_dfc,
    [EnumMember(Value = "prototype")]
    Prototype,
    [EnumMember(Value = "class")]
    Class,
    [EnumMember(Value = "reversible_card")]
    ReversibleCard,
    [EnumMember(Value = "case")]
    Case,


}
