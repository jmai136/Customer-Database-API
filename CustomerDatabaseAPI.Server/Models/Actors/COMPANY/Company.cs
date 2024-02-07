using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using CustomerDatabaseAPI.Server.Models.General;

namespace CustomerDatabaseAPI.Server.Models.Actors.COMPANY
{
    public class Company
    {
        private enum ECompanyIndustry
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

        [Key]
        public int CompanyID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        [Required]
        [EnumDataType(typeof(ECompanyIndustry))]
        public object CompanyIndustry;


        // 1 - MANY

        [Required]
        IList<CustomerSupportRepresentative> CustomerSupportRepresentatives { get; set; }

        [Required]
        IList<CompanyInfo> CompanyInfos { get; set; }
    }
}
