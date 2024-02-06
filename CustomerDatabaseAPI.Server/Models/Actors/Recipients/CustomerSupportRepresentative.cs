﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.PERSON;

namespace CustomerDatabaseAPI.Server.Models.Actors.Recipients
{
    public class CustomerSupportRepresentative
    {
        [Key]
        public int CustomerSupportRepresentativeID { get; set; }

        public int PersonID { get; set; }
        [Required, ForeignKey("PersonId")]
        public Person Person { get; set; }

        public int CompanyID { get; set; }
        [Required, ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}