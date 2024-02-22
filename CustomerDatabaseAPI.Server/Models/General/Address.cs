using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.General
{
    public enum EAddressType
    {
        [Display(Name = "Domicile")]
        DOMICILE,
        [Display(Name = "Mailing")]
        MAILING,
        [Display(Name = "Business")]
        BUSINESS
    }

    public enum EStatesAbbreviations
    {
        [Display(Name = "Alabama")]
        AL,

        [Display(Name = "Alaska")]
        AK,

        [Display(Name = "Arizona")]
        AZ,

        [Display(Name = "Arkansas")]
        AR,

        [Display(Name = "California")]
        CA,

        [Display(Name = "Colorado")]
        CO,

        [Display(Name = "Connecticut")]
        CT,

        [Display(Name = "Delaware")]
        DE,

        [Display(Name = "District of Columbia")]
        DC,

        [Display(Name = "Florida")]
        FL,

        [Display(Name = "Georgia")]
        GA,

        [Display(Name = "Hawaii")]
        HI,

        [Display(Name = "Idaho")]
        ID,

        [Display(Name = "Illinois")]
        IL,

        [Display(Name = "Indiana")]
        IN,

        [Display(Name = "Iowa")]
        IA,

        [Display(Name = "Kansas")]
        KS,

        [Display(Name = "Kentucky")]
        KY,

        [Display(Name = "Louisiana")]
        LA,

        [Display(Name = "Maine")]
        ME,

        [Display(Name = "Maryland")]
        MD,

        [Display(Name = "Massachusetts")]
        MA,

        [Display(Name = "Michigan")]
        MI,

        [Display(Name = "Minnesota")]
        MN,

        [Display(Name = "Mississippi")]
        MS,

        [Display(Name = "Missouri")]
        MO,

        [Display(Name = "Montana")]
        MT,

        [Display(Name = "Nebraska")]
        NE,

        [Display(Name = "Nevada")]
        NV,

        [Display(Name = "New Hampshire")]
        NH,

        [Display(Name = "New Jersey")]
        NJ,

        [Display(Name = "New Mexico")]
        NM,

        [Display(Name = "New York")]
        NY,

        [Display(Name = "North Carolina")]
        NC,

        [Display(Name = "North Dakota")]
        ND,

        [Display(Name = "Ohio")]
        OH,

        [Display(Name = "Oklahoma")]
        OK,

        [Display(Name = "Oregon")]
        OR,

        [Display(Name = "Pennsylvania")]
        PA,

        [Display(Name = "Rhode Island")]
        RI,

        [Display(Name = "South Carolina")]
        SC,

        [Display(Name = "South Dakota")]
        SD,

        [Display(Name = "Tennessee")]
        TN,

        [Display(Name = "Texas")]
        TX,

        [Display(Name = "Utah")]
        UT,

        [Display(Name = "Vermont")]
        VT,

        [Display(Name = "Virginia")]
        VA,

        [Display(Name = "Washington")]
        WA,

        [Display(Name = "West Virginia")]
        WV,

        [Display(Name = "Wisconsin")]
        WI,

        [Display(Name = "Wyoming")]
        WY
    }

    [Table("Address", Schema = "CustomerDatabase")]
    public class Address
    { 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        [Required, MaxLength(100)]
        public string AddressLineOne { get; set; }

        [Required, MaxLength(100)]
        public string AddressLineTwo { get; set; }

        [Required, EnumDataType(typeof(EAddressType))]
        public EAddressType AddressType;

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, EnumDataType(typeof(EStatesAbbreviations))]
        public EStatesAbbreviations State;

        [Required, MaxLength(11)]
        public string Zipcode;




        // 1 - MANY

        [Required]
        public List<PersonInfo>? PersonInfos { get; set; }

        [Required]
        public List<CompanyInfo>? CompanyInfos { get; set; }
    }
}
