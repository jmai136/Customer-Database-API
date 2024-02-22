using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;

namespace CustomerDatabaseAPI.Server.Models.Actors.CALL
{
    [Table("Call", Schema = "CustomerDatabase")]
    public class Call
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CallID { get; set; }

        public int? CallNotesID;
        // 1 - many
        [ForeignKey("CallNotesID")]
        public CallNotes? CallNotes { get; set; }

        [Required]
        public DateTime CallDurationStartDateTime { get; set; }

        [Required]
        public DateTime CallDurationEndDateTime { get; set; }
            /*
        {
            get
            {
                return CallDurationEndDateTime;
            }
            set
            {
                CallDurationEndDateTime = (value < CallDurationStartDateTime) ? CallDurationStartDateTime : value;
            }
        }*/

        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        public int? CustomerSupportRepresentativeID { get; set; }
        [ForeignKey("CustomerSupportRepresentativeID")]
        public CustomerSupportRepresentative? CustomerSupportRepresentative { get; set; }
    }
}
