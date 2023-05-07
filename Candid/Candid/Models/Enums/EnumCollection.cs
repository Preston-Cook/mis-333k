using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Candid.Models;

public enum PositionType
{
    [Display(Name = "Full-Time")]
    FT,
    [Display(Name = "Internship")]
    I
}

public enum Gender
{
    [Display(Name = "Female")]
    F,
    [Display(Name = "Male")]
    M,
    [Display(Name = "Other")]
    Other
}

public enum Ethnicity
{
    [Display(Name = "Asian")]
    Asian,
    [Display(Name = "American Indian/Alaskan Native")]
    AmericanIndianOrAlaskanNative,
    [Display(Name = "Black/African-American")]
    BlackOrAfricanAmerican,
    [Display(Name = "Hispanic")]
    Hispanic,
    [Display(Name = "Pacific Islander")]
    NativeHawaiianandOtherPacificIslander,
    [Display(Name = "Two or More Ethnicities")]
    TwoOrMoreRaces,
    [Display(Name = "White")]
    White
}

public enum StateType 
{ 
    AL,
    AK,
    AZ,
    AR,
    CA,
    CO,
    CT,
    DE,
    DC,
    FL,
    GA,
    HI,
    ID,
    IL,
    IN,
    IA,
    KS,
    KY,
    LA,
    ME,
    MD,
    MA,
    MI,
    MN,
    MS,
    MO,
    MT,
    NE,
    NV,
    NH,
    NJ,
    NM,
    NY,
    NC,
    ND,
    OH,
    OK, 
    OR,
    PA,
    PR,
    RI,
    SC,
    SD,
    TN,
    TX,
    UT,
    VT,
    VA,
    VI,
    WA,
    WV,
    WI,
    WY
}

public enum StatusType 
{
    [Display(Name = "Pending")]
    Pending, 
    [Display(Name = "Accepted")]
    Accepted, 
    [Display(Name = "Denied")]
    Denied
}

public enum IndustryTypes 
{
    [Display(Name = "Accounting")]
    Accounting,
    [Display(Name = "Chemicals")]
    Chemicals,
    [Display(Name = "Consulting")]
    Consulting,
    [Display(Name = "Energy")]
    Energy, 
    [Display(Name = "Engineering")]
    Engineering,
    [Display(Name ="Financial Services")]
    FinancialServices,
    [Display(Name = "Hospitality")]
    Hospitality, 
    [Display(Name = "Insurance")]
    Insurance,
    [Display(Name = "Manufacturing")]
    Manufacturing,
    [Display(Name = "Marketing")]
    Marketing,

    [Display(Name ="Real Estate")]
    RealEstate,
    [Display(Name = "Retail")]
    Retail, 
    [Display(Name = "Technology")]
    Technology, 
    [Display(Name = "Transportation")]
    Transportation
}

public enum RoomType 
{
    [Display(Name = "Room 1")]
    One,
    [Display(Name = "Room 2")] 
    Two, 
    [Display(Name = "Room 3")]
    Three,
    [Display(Name = "Room 4")]
    Four
}

public enum MajorCodes
{
    [Display(Name = "Accounting")]
    ACC,
    [Display(Name = "Canfield Business Honors Program")]
    CBHP,
    [Display(Name = "Finance")]
    FIN,
    [Display(Name = "International Business")]
    IB,
    [Display(Name = "Management")]
    MAN,
    [Display(Name = "Management Information Systems")]
    MIS,
    [Display(Name = "Marketing")]
    MKT,
    [Display(Name = "Business Analytics")]
    SCM,
    [Display(Name = "Science and Technology Management")]
    STM
}