using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.General
{
    [Table("Email")]
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


        // 1 - MANY

        [Required]
        IList<PersonInfo> PersonInfos { get; set; }

        [Required]
        IList<CompanyInfo> CompanyInfos { get; set; }
    }
}
