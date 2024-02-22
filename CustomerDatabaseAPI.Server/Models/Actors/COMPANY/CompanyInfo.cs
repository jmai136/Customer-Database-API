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

        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }

        [ForeignKey("AddressID")]
        public Address? Address { get; set; }
    
        [ForeignKey("PhoneNumberID")]
        public PhoneNumber? PhoneNumber { get; set; }

        [ForeignKey("EmailID")]
        public Email? Email { get; set; }
    }
}
