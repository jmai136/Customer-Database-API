using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.General;
using Microsoft.EntityFrameworkCore;

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
            // I shouldn't have to configure the entity or key due to already doing that in my model
            modelBuilder.Entity<Person>()
                .HasMany(person => person.PersonInfos);

            // Adds seed data, temporary, might just make a DBSeed class
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
                                PersonInfoID = 0
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
                    });

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
            ) ;

            modelBuilder.Entity<Company>()
                .Property(company => company.CompanyIndustry)
                .HasConversion<int>();
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
