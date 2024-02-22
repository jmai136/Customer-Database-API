using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.General
{
    public enum EAddressType
    {
        DOMICILE,
        MAILING,
        BUSINESS
    }

    public enum EStatesAbbreviations
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
        RI,
        SC,
        SD,
        TN,
        TX,
        UT,
        VT,
        VA,
        WA,
        WV,
        WI,
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
        public List<PersonInfo> PersonInfos { get; set; }

        [Required]
        public List<CompanyInfo> CompanyInfos { get; set; }
    }
}
