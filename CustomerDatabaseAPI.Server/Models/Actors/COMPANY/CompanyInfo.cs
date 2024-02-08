using CustomerDatabaseAPI.Server.Models.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.COMPANY
{
    [Table("CompanyInfo")]
    public class CompanyInfo
    {
        public int CompanyInfoID { get; set; }

        public int CompanyID { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int AddressID { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        public int PhoneNumberID { get; set; }
        [ForeignKey("PhoneNumberId")]
        public PhoneNumber PhoneNumber { get; set; }

        public int EmailID { get; set; }
        [ForeignKey("EmailId")]
        public Email Email { get; set; }
    }
}
