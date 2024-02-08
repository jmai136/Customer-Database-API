using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.PERSON
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }


        // 1 - MANY

        [Required]
        IList<PersonInfo> PersonInfos { get; set; }
    }
}
