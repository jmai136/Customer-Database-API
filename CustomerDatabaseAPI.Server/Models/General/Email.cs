using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.General
{
    public enum EEmailAccountType
    {
        HOME,
        BUSINESS,
        ACADEMIC
    }

    [Table("Email")]
    public class Email
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmailID { get; set; }

        [Required, MaxLength(320)]
        public string EmailCharacters { get; set; }

        [Required, EnumDataType(typeof(EEmailAccountType))]
        public EEmailAccountType EmailAccountType;


        // 1 - MANY

        [Required]
        public List<PersonInfo> PersonInfos { get; set; }

        [Required]
        public List<CompanyInfo> CompanyInfos { get; set; }
    }
}
