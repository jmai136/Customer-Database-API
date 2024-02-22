using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;

namespace CustomerDatabaseAPI.Server.Models.Actors.Recipients
{
    [Table("Customer", Schema = "CustomerDatabase")]
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }


        // Foreign key property
        public int PersonID { get; set; }

        // Navigation property
        [ForeignKey("PersonID")]
        public Person? Person { get; set; }


        // 1 - MANY

        [Required]
        public List<Call>? Calls { get; set; }
    }
}
