using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;

namespace CustomerDatabaseAPI.Server.Models.Actors.Recipients
{
    [Table("Csr", Schema = "CustomerDatabase")]
    public class CustomerSupportRepresentative
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerSupportRepresentativeID { get; set; }

        // Foreign key property
        public int? PersonID { get; set; }
        // Navigation property
        [ForeignKey("PersonID")]
        public Person? Person { get; set; }

        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }


        // 1 - MANY

        [Required]
        public List<Call>? Calls { get; set; }
    }
}
