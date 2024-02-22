using CustomerDatabaseAPI.Server.Models.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.COMPANY
{
    [Table("CompanyInfo", Schema = "CustomerDatabase")]
    public class CompanyInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyInfoID { get; set; }

        public int? CompanyID;
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }

        public int? AddressID;
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }

        public int? PhoneNumberID;
        [ForeignKey("PhoneNumberID")]
        public PhoneNumber? PhoneNumber { get; set; }

        public int? EmailID;
        [ForeignKey("EmailID")]
        public Email? Email { get; set; }
    }
}
