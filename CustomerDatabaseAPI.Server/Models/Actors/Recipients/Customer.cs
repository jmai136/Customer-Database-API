using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;

namespace CustomerDatabaseAPI.Server.Models.Actors.Recipients
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public int PersonID { get; set; }
        [Required, ForeignKey("PersonId")]
        public Person Person { get; set; }


        // 1 - MANY

        [Required]
        IList<Call> Calls { get; set; }
    }
}
