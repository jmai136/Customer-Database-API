using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseAPI.Server.Models.General
{
    public class Email
    {
        private enum EEmailAccountType
        {
            HOME,
            BUSINESS,
            ACADEMIC
        }

        [Key]
        public int EmailID { get; set; }

        [Required, MaxLength(320)]
        public string EmailCharacters { get; set; }

        [Required, EnumDataType(typeof(Email.EEmailAccountType))]
        public object EmailAccountType;
    }
}
