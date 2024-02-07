using CustomerDatabaseAPI.Server.Models.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.PERSON
{
    [Table("PersonInfo")]
    public class PersonInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonInfoID { get; set; }

        public int PersonID { get; set; }
        [Required, ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int AddressID { get; set; }
        [Required, ForeignKey("AddressId")]
        public Address Address { get; set; }

        public int PhoneNumberID { get; set; }
        [Required, ForeignKey("PhoneNumberID")]
        public PhoneNumber PhoneNumber { get; set; }

        public int EmailID { get; set; }
        [Required, ForeignKey("EmailId")]
        public Email Email { get; set; }
    }
}
