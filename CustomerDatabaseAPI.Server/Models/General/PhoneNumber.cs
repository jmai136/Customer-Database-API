using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseAPI.Server.Models.General
{
    public class PhoneNumber
    {
        private enum EPhoneNumberType
        {
            HOME,
            WORK,
            MOBILE
        }

        [Key]
        public int PhoneNumberId { get; set; }

        [Required, MaxLength(11)]
        public string PhoneNumberDigits { get; set; }

        [Required, EnumDataType(typeof(EPhoneNumberType))]
        public object PhoneNumberType;
    }
}
