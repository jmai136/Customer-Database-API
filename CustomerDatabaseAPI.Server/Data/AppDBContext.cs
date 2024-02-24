using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net;

namespace CustomerDatabaseAPI.Server.Data
{
    public class AppDBContext : IdentityDbContext
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
                .HasMany(person => person.PersonInfos)
                .WithOne(personInfo => personInfo.Person);

            /**************** ADDRESS *******************/
            modelBuilder.Entity<Address>()
                .HasMany(address => address.PersonInfos)
                .WithOne(personInfo => personInfo.Address)
                .HasForeignKey(address => address.PersonInfoID);
            modelBuilder.Entity<Address>()
                .HasMany(address => address.CompanyInfos)
                .WithOne(companyInfo => companyInfo.Address)
                .HasForeignKey(address => address.CompanyInfoID);

            modelBuilder.Entity<Address>()
                .Property(address => address.AddressType)
                .HasConversion<string>();
            modelBuilder.Entity<Address>()
                .Property(address => address.State)
                .HasConversion<string>();

            /**************** PHONE NUMBER *******************/
            modelBuilder.Entity<PhoneNumber>()
                .HasMany(phoneNumber=> phoneNumber.PersonInfos)
                .WithOne(personInfo => personInfo.PhoneNumber)
                .HasForeignKey(phoneNumber => phoneNumber.PersonInfoID);
            modelBuilder.Entity<PhoneNumber>()
                .HasMany(phoneNumber => phoneNumber.CompanyInfos)
                .WithOne(companyInfo => companyInfo.PhoneNumber)
                .HasForeignKey(phoneNumber => phoneNumber.CompanyInfoID);

            modelBuilder.Entity<PhoneNumber>()
                .Property(phoneNumber => phoneNumber.PhoneNumberType)
                .HasConversion<string>();

            /**************** EMAIL *******************/
            modelBuilder.Entity<Email>()
                .HasMany(email => email.PersonInfos)
                .WithOne(personInfo => personInfo.Email)
                .HasForeignKey(personInfo => personInfo.PersonInfoID);
            modelBuilder.Entity<Email>()
                .HasMany(email => email.CompanyInfos)
                .WithOne(companyInfo => companyInfo.Email)
                .HasForeignKey(companyInfo => companyInfo.CompanyInfoID);

            modelBuilder.Entity<Email>()
                .Property(email => email.EmailAccountType)
                .HasConversion<string>();

            /**************** CUSTOMER *******************/
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Calls)
                .WithOne(call => call.Customer)
                .HasForeignKey(call => call.CallID);

            modelBuilder.Entity<Customer>()
                .HasOne(customer => customer.Person)
                .WithOne(person => person.Customer)
                .HasForeignKey<Customer>(customer => customer.PersonID);

            /**************** CSR *******************/
            modelBuilder.Entity<CustomerSupportRepresentative>()
                .HasMany(csr => csr.Calls)
                .WithOne(call => call.CustomerSupportRepresentative);

            /**************** COMPANY *******************/
            modelBuilder.Entity<Company>()
                .Property(company => company.CompanyIndustry)
                .HasConversion<string>();

            modelBuilder.Entity<Company>()
                .HasMany(company => company.CustomerSupportRepresentatives)
                .WithOne(csr => csr.Company);

            /**************** CALLS *******************/
            modelBuilder.Entity<CallNotes>()
               .HasMany(callNote => callNote.Calls)
               .WithOne(call => call.CallNotes);

            modelBuilder.Entity<CallNotes>()
                .Property(callNote => callNote.CallReasonType)
                .HasConversion<string>();

            // Adds seed data, temporary, might just make a DBSeed class in the future
            modelBuilder.Entity<Person>().
                HasData(
                    new Person {
                        PersonID = 1,
                        FirstName = "Genji",
                        LastName = "Shimada",
                        BirthDate = new DateOnly(1997, 10, 25)
                    },
                    new Person
                    {
                        PersonID = 2,
                        FirstName = "Hanzo",
                        LastName = "Shimada",
                        BirthDate = new DateOnly(1990, 3, 14)
                    },
                    new Person
                    {
                        PersonID = 3,
                        FirstName = "Lena",
                        LastName = "Oxton",
                        BirthDate = new DateOnly(2007, 2, 17)
                    });

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    AddressID = 1,
                    AddressLineOne = "9929 Sulphur Springs Ave. Muskego",
                    AddressLineTwo = "",
                    AddressType = EAddressType.DOMICILE,
                    City = "Milwaukee",
                    State = EStatesAbbreviations.WI,
                    Zipcode = "56032"
                },
                new Address
                {
                    AddressID = 2,
                    AddressLineOne = "17 Fairview Road Cheaspeake",
                    AddressLineTwo = "",
                    AddressType = EAddressType.BUSINESS,
                    City = "Toledo",
                    State = EStatesAbbreviations.CA,
                    Zipcode = "78402"
                },
                new Address
                {
                    AddressID = 3,
                    AddressLineOne = "871 Hillside Ave. Palm Harbor",
                    AddressLineTwo = "",
                    AddressType = EAddressType.DOMICILE,
                    City = "New York City",
                    State = EStatesAbbreviations.AL,
                    Zipcode = "34680"
                }
            );

            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    EmailID = 1,
                    EmailCharacters = "shimadabro@gmail.com",
                    EmailAccountType = EEmailAccountType.HOME
                },
                new Email
                {
                    EmailID = 2,
                    EmailCharacters = "shimadaclan@gmail.com",
                    EmailAccountType = EEmailAccountType.HOME
                },
                new Email
                {
                    EmailID = 3,
                    EmailCharacters = "thecavalryishere@yahoo.com",
                    EmailAccountType = EEmailAccountType.HOME
                }
            );

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber
                {
                    PhoneNumberID = 1,
                    PhoneNumberDigits = "1925064920",
                    PhoneNumberType = EPhoneNumberType.WORK
                },
                new PhoneNumber
                {
                    PhoneNumberID = 2,
                    PhoneNumberDigits = "7392018402",
                    PhoneNumberType = EPhoneNumberType.WORK
                },
                new PhoneNumber
                {
                    PhoneNumberID = 3,
                    PhoneNumberDigits = "9428018394",
                    PhoneNumberType = EPhoneNumberType.WORK
                }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyID = 1,
                    CompanyName = "The Shimada Clan",
                    CompanyDescription = "",
                    CompanyIndustry = ECompanyIndustry.HOSPITALITY
                }
            );

            modelBuilder.Entity<CallNotes>().HasData(
                new CallNotes
                {
                    CallNotesID = 1,
                    CallNotesDescription = "",
                    CallReasonType = ECallReasonType.BILLING_AND_PAYMENT,
                    IsResolved = 1
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    PersonID = 1
                },
                new Customer
                {
                    CustomerID = 2,
                    PersonID = 3
                }
            );

            modelBuilder.Entity<CustomerSupportRepresentative>().HasData(
                new CustomerSupportRepresentative
                { 
                    CustomerSupportRepresentativeID = 1,
                    PersonID = 2,
                    CompanyID = 1
                }
            );

            modelBuilder.Entity<PersonInfo>().
                HasData(
                    new PersonInfo
                    {
                        PersonInfoID = 1,
                        PersonID = 1,
                        AddressID = 1,
                        PhoneNumberID = 1,
                        EmailID = 1
                    },
                    new PersonInfo
                    {
                        PersonInfoID = 2,
                        PersonID = 2,
                        AddressID = 1,
                        PhoneNumberID = 1,
                        EmailID = 1
                    },
                    new PersonInfo
                    {
                        PersonInfoID = 3,
                        PersonID = 3,
                        AddressID = 3,
                        PhoneNumberID = 3,
                        EmailID = 3
                    });

            modelBuilder.Entity<CompanyInfo>().HasData(
                new CompanyInfo
                {
                    CompanyInfoID = 1,
                    CompanyID = 1,
                    AddressID = 2,
                    PhoneNumberID = 2,
                    EmailID = 2
                }
            );

            modelBuilder.Entity<Call>().HasData(
                new Call
                {
                    CallID = 1,
                    CallNotesID = 1,
                    CallDurationStartDateTime = new DateTime(2020, 12, 5, 17, 25, 09),
                    CallDurationEndDateTime = new DateTime(2020, 12, 5, 19, 30, 17),
                    CustomerID = 1,
                    CustomerSupportRepresentativeID = 1
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
