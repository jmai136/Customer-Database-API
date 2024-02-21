using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.General;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CustomerDatabaseAPI.Server.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Call> Call { get; set; }

        public DbSet<CallNotes> CallNotes { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<CompanyInfo> CompanyInfo { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<PersonInfo> PeopleInfo { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerSupportRepresentative> CustomerSupportRepresentatives { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Email> Email { get; set; }

        public DbSet<PhoneNumber> PhoneNumber { get; set; }

        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Again, typically you'd use builder which is created in Program.cs and then grab the JSON values
            var ConfigurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            string ConnectionString = AzureConfigurationManager.GetConnectionString(ConfigurationBuilder.GetValue<string>("KeyVault:VaultName"), ConfigurationBuilder.GetValue<string>("KeyVault:SecretName"));

            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**************** PERSON *******************/

            // I shouldn't have to configure the entity or key due to already doing that in my model
            modelBuilder.Entity<Person>()
                .HasMany(person => person.PersonInfos);

            // Adds seed data, temporary, might just make a DBSeed class in the future
            modelBuilder.Entity<Person>().
                HasData(
                    new Person {
                        PersonID = 0,
                        FirstName = "Genji",
                        LastName = "Shimada",
                        BirthDate = new DateOnly(1997, 10, 25),
                        PersonInfos = new List<PersonInfo>
                        {
                            new PersonInfo
                            {
                                PersonInfoID = 0
                            }
                        }
                    },
                    new Person
                    {
                        PersonID = 1,
                        FirstName = "Hanzo",
                        LastName = "Shimada",
                        BirthDate = new DateOnly(1990, 3, 14),
                        PersonInfos = new List<PersonInfo>
                        {
                            new PersonInfo
                            {
                                PersonInfoID = 1
                            }
                        }
                    });

            modelBuilder.Entity<PersonInfo>().
                HasData(
                    new PersonInfo
                    {
                        PersonInfoID = 0,
                        Person = new Person {
                            PersonID = 0
                        },
                        Address = new Address
                        {
                            AddressID = 0
                        },
                        PhoneNumber = new PhoneNumber
                        {
                            PhoneNumberID = 0
                        },
                        Email = new Email
                        {
                            EmailID = 0
                        }
                    },
                    new PersonInfo
                    {
                        PersonInfoID = 1,
                        Person = new Person
                        {
                            PersonID = 1
                        },
                        Address = new Address
                        {
                            AddressID = 0
                        },
                        PhoneNumber = new PhoneNumber
                        {
                            PhoneNumberID = 0
                        },
                        Email = new Email
                        {
                            EmailID = 0
                        }
                    });

            /**************** ADDRESS *******************/
            modelBuilder.Entity<Address>()
                .HasMany(address => address.PersonInfos);
            modelBuilder.Entity<Address>()
                .HasMany(address => address.CompanyInfos);

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    AddressID = 0,
                    AddressLineOne = "9929 Sulphur Springs Ave. Muskego",
                    AddressLineTwo = "",
                    City = "Milwaukee",
                    State = EStatesAbbreviations.WI,
                    Zipcode = "56032",
                    PersonInfos = new List<PersonInfo>
                    {
                        new PersonInfo
                        {
                            PersonInfoID = 0
                        },
                        new PersonInfo
                        {
                            PersonInfoID = 1
                        }
                    },
                    CompanyInfos = new List<CompanyInfo>
                    {
                    },
                },
                new Address
                {
                    AddressID = 1,
                    AddressLineOne = "17 Fairview Road Cheaspeake",
                    AddressLineTwo = "",
                    City = "Toledo",
                    State = EStatesAbbreviations.CA,
                    Zipcode = "784023",
                    PersonInfos = new List<PersonInfo>
                    {
                        new PersonInfo
                        {
                            PersonInfoID = 1
                        }
                    },
                    CompanyInfos = new List<CompanyInfo>
                    {
                        new CompanyInfo
                        {
                            CompanyInfoID = 0
                        }
                    },
                }
            );

            /**************** PHONE NUMBER *******************/
            modelBuilder.Entity<PhoneNumber>()
                .HasMany(phoneNumber=> phoneNumber.PersonInfos);
            modelBuilder.Entity<PhoneNumber>()
                .HasMany(phoneNumber => phoneNumber.CompanyInfos);

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber
                {
                    PhoneNumberID = 0,
                    PhoneNumberDigits = "1925064920",
                    PhoneNumberType = EPhoneNumberType.WORK,
                    PersonInfos = new List<PersonInfo>
                    {
                        new PersonInfo
                        {
                            PersonInfoID = 0
                        },
                        new PersonInfo
                        {
                            PersonInfoID = 1
                        }
                    },
                    CompanyInfos = new List<CompanyInfo>
                    {
                    }
                },
                new PhoneNumber
                {
                    PhoneNumberID = 1,
                    PhoneNumberDigits = "7392018402",
                    PhoneNumberType = EPhoneNumberType.WORK,
                    PersonInfos = new List<PersonInfo>
                    {
                    },
                    CompanyInfos = new List<CompanyInfo>
                    {
                        new CompanyInfo
                        {
                            CompanyInfoID = 0
                        }
                    }
                }
            );

            /**************** EMAIL *******************/
            modelBuilder.Entity<Email>()
                .HasMany(phoneNumber => phoneNumber.PersonInfos);
            modelBuilder.Entity<Email>()
                .HasMany(phoneNumber => phoneNumber.CompanyInfos);

            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    EmailID = 0,
                    EmailCharacters = "shimadabro@gmail.com",
                    EmailAccountType = EEmailAccountType.HOME,
                    PersonInfos = new List<PersonInfo>
                    {
                        new PersonInfo
                        {
                            PersonInfoID = 0
                        },
                        new PersonInfo
                        {
                            PersonInfoID = 1
                        }
                    },
                    CompanyInfos = new List<CompanyInfo>
                    {
                    }
                },
                new Email
                {
                    EmailID = 1,
                    EmailCharacters = "shimadaclan@gmail.com",
                    EmailAccountType = EEmailAccountType.HOME,
                    PersonInfos = new List<PersonInfo>
                    {
                    },
                    CompanyInfos = new List<CompanyInfo>
                    {
                        new CompanyInfo
                        {
                            CompanyInfoID = 0
                        }
                    }
                }
            );

            /**************** CUSTOMER *******************/

            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Calls);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 0,
                    Person = new Person
                    {
                        PersonID = 0
                    },
                    Calls = new List<Call>
                    {
                        new Call
                        {
                            CallID = 0
                        }
                    }
                }
            );

            /**************** CSR *******************/

            modelBuilder.Entity<CustomerSupportRepresentative>()
                .HasMany(csr => csr.Calls);

            modelBuilder.Entity<CustomerSupportRepresentative>().HasData(
                new CustomerSupportRepresentative
                { 
                    CustomerSupportRepresentativeID = 0,
                    PersonID = 1,
                    CompanyID = 0,
                    Calls = new List<Call>
                    {
                        new Call
                        {
                            CallID = 0
                        }
                     }
                }
            );

            /**************** COMPANY *******************/

            modelBuilder.Entity<Company>()
                .Property(company => company.CompanyIndustry)
                .HasConversion<string>();

            modelBuilder.Entity<Company>()
                .HasMany(company => company.CustomerSupportRepresentatives);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyID = 0,
                    CompanyName = "The Shimada Clan",
                    CompanyIndustry = ECompanyIndustry.HOSPITALITY,
                    CustomerSupportRepresentatives = new List<CustomerSupportRepresentative>
                    {
                        new CustomerSupportRepresentative
                        {
                            CustomerSupportRepresentativeID = 0
                        }
                    }
                }
            );

            modelBuilder.Entity<CompanyInfo>().HasData(
                new CompanyInfo
                {
                    CompanyInfoID = 0,
                    CompanyID = 0,
                    AddressID = 1,
                    PhoneNumberID = 1,
                    EmailID = 1
                }
            );

            /**************** CALLS *******************/
            modelBuilder.Entity<Call>().HasData(
                new Call
                {
                    CallID = 0,
                    CallNotes = new CallNotes
                    {
                        CallNotesID = 0
                    },
                    CallDurationStartDateTime = new DateTime(2020, 12, 5, 17, 25, 09),
                    CallDurationEndDateTime = new DateTime(2020, 12, 5, 19, 30, 17),
                    Customer = new Customer
                    {
                        CustomerID = 0
                    },
                    CustomerSupportRepresentative = new CustomerSupportRepresentative
                    {
                        CustomerSupportRepresentativeID = 0
                    }
                }
            );

            modelBuilder.Entity<CallNotes>().HasData(
                new CallNotes
                {
                    CallNotesID = 0,
                    CallNotesDescription = "",
                    CallReasonType = ECallReasonType.BILLING_AND_PAYMENT,
                    IsResolved = 1,
                    Calls = new List<Call> 
                    {
                        new Call
                        {
                            CallID = 0
                        }
                    }
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
