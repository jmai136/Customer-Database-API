using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;

namespace CustomerDatabaseAPI.Server.Models.Actors.CALL
{
    public class Call
    {
        [Key]
        public int CallID { get; set; }

        // 1 - many
        [Required]
        public int CallNotesID { get; set; }
        [ForeignKey("CallNotesID")]
        public CallNotes CallNotes { get; set; }

        [Required]
        public DateTime CallDurationStartDateTime { get; set; }

        [Required]
        public DateTime CallDurationEndDateTime
        {
            get
            {
                return CallDurationEndDateTime;
            }
            set
            {
                CallDurationEndDateTime = (value < CallDurationStartDateTime) ? CallDurationStartDateTime : value;
            }
        }

        public int CustomerID { get; set; }
        [Required, ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int CustomerSupportRepresentativeID { get; set; }
        [Required, ForeignKey("CustomerSupportRepresentativeID")]
        public CustomerSupportRepresentative CustomerSupportRepresentative { get; set; }
    }
}
