using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseAPI.Server.Models.Actors.CALL
{
    public enum ECallReasonType
    {
        [Display(Name = "Product Inquiries and Info")]
        PRODUCT_INQUIRIES_AND_INFO,

        [Display(Name = "Order Related")]
        ORDER_RELATED,

        [Display(Name = "Technical Support")]
        TECHNICAL_SUPPORT,

        [Display(Name = "Billing and Payment")]
        BILLING_AND_PAYMENT,

        [Display(Name = "Complaints and Feedback")]
        COMPLAINTS_AND_FEEDBACK,

        [Display(Name = "Returns and Exchanges")]
        RETURNS_AND_EXCHANGES,

        [Display(Name = "Account Management")]
        ACCOUNT_MANAGEMENT,

        [Display(Name = "General Assistance")]
        GENERAL_ASSISTANCE,

        [Display(Name = "Promotions and Loyalty Programs")]
        PROMOTIONS_AND_LOYALTY_PROGRAMS,

        [Display(Name = "Legal Matters")]
        LEGAL_MATTERS
    }

    [Table("CallNotes", Schema = "CustomerDatabase")]
    public class CallNotes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CallNotesID { get; set; }

        public string? CallNotesDescription { get; set; }

        [Required, EnumDataType(typeof(ECallReasonType))]
        public ECallReasonType CallReasonType;

        [Required]
        public byte IsResolved { get; set; }

        [Required]
        public List<Call>? Calls { get; set; }
    }
}
