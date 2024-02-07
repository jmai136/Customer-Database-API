using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseAPI.Server.Models.Actors.PERSON
{
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
