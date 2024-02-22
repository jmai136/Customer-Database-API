using CustomerDatabaseAPI.Server.Models.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.PERSON
{
    [Table("PersonInfo", Schema = "CustomerDatabase")]
    public class PersonInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonInfoID { get; set; }

        public int? PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person? Person { get; set; }

        public int? AddressID { get; set; }
        [ForeignKey("AddressID")]
        public Address? Address { get; set; }

        public int? PhoneNumberID { get; set; }
        [ForeignKey("PhoneNumberID")]
        public PhoneNumber? PhoneNumber { get; set; }

        public int? EmailID { get; set; }
        [ForeignKey("EmailID")]
        public Email? Email { get; set; }
    }
}
