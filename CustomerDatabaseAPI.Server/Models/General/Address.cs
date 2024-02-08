using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.General
{
    [Table("Address")]
    public class Address
    {
        private enum EAddressType
        {
            DOMICILE,
            MAILING,
            BUSINESS
        }

        private enum EStatesAbbreviations
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

        private enum EZipcodes
        {
        }

        [Key]
        public int AddressID { get; set; }

        [Required, MaxLength(100)]
        public string AddressLineOne { get; set; }

        [Required, MaxLength(100)]
        public string AddressLineTwo { get; set; }

        [Required, EnumDataType(typeof(EAddressType))]
        public object AddressType;

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, EnumDataType(typeof(EStatesAbbreviations))]
        public object State;

        [Required, EnumDataType(typeof(EZipcodes))]
        public object Zipcode;




        // 1 - MANY

        [Required]
        IList<PersonInfo> PersonInfos { get; set; }

        [Required]
        IList<CompanyInfo> CompanyInfos { get; set; }
    }
}
