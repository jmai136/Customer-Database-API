using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.General
{
    [Table("PhoneNumber")]
    public class PhoneNumber
    {
        private enum EPhoneNumberType
        {
            HOME,
            WORK,
            MOBILE
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneNumberID { get; set; }

        [Required, MaxLength(11)]
        public string PhoneNumberDigits { get; set; }

        [Required, EnumDataType(typeof(EPhoneNumberType))]
        public object PhoneNumberType;



        // 1 - MANY

        [Required]
        public List<PersonInfo> PersonInfos { get; set; }

        [Required]
        public List<CompanyInfo> CompanyInfos { get; set; }
    }
}
