using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseAPI.Server.Models.Actors.CALL
{
    public class CallDuration
    {
        [Key]
        public int CallDurationID { get; set; }

        [Required]
        public DateTime CallDurationStartDateTime { get; set; }

        [Required]
        public DateTime CallDurationEndDateTime { get; set; }
    }
}
