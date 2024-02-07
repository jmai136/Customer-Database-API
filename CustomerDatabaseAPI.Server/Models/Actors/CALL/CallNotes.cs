using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.CALL
{
    [Table("CallNotes")]
    public class CallNotes
    {
        private enum ECallReasonType
        {
            PRODUCT_INQUIRIES_AND_INFO,
            ORDER_RELATED,
            TECHNICAL_SUPPORT,
            BILLING_AND_PAYMENT,
            COMPLAINTS_AND_FEEDBACK,
            RETURNS_AND_EXCHANGES,
            ACCOUNT_MANAGEMENT,
            GENERAL_ASSISTANCE,
            PROMOTIONS_AND_LOYALTY_PROGRAMS,
            LEGAL_MATTERS
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CallNotesID { get; set; }

        public string CallNotesDescription { get; set; }

        [Required, EnumDataType(typeof(ECallReasonType))]
        public object CallReasonType;

        [Required]
        public byte IsResolved { get; set; }

        [Required]
        public List<Call> Calls { get; set; }
    }
}
