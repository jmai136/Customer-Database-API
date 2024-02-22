using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using CustomerDatabaseAPI.Server.Models.General;

namespace CustomerDatabaseAPI.Server.Models.Actors.COMPANY
{
    public enum ECompanyIndustry
    {
        MANUFACTURING,
        TECHNOLOGY,
        FINANCIAL,
        RETAIL,
        HEALTHCARE,
        TELECOMMUNICATIONS,
        ENERGY,
        CONSTRUCTION,
        TRANSPORTATION,
        HOSPITALITY,
        FOOD,
        ENTERTAINMENT
    }

    [Table("Company", Schema = "CustomerDatabase")]
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        [Required]
        [EnumDataType(typeof(ECompanyIndustry))]
        public ECompanyIndustry CompanyIndustry;


        // 1 - MANY

        [Required]
        public List<CustomerSupportRepresentative> CustomerSupportRepresentatives { get; set; }

        [Required]
        public List<CompanyInfo> CompanyInfos { get; set; }
    }
}
