using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;

namespace CustomerDatabaseAPI.Server.Models.Actors.Recipients
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public int PersonID { get; set; }
        [Required, ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
