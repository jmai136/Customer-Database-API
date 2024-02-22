using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.PERSON
{
    [Table("Person", Schema = "CustomerDatabase")]
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }



 
        // 1 - MANY
        [Required]
        public List<PersonInfo>? PersonInfos { get; set; }
    }
}
