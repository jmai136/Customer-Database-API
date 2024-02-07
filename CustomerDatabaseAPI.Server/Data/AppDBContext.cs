using CustomerDatabaseAPI.Server.Models.Actors.PERSON;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;
using CustomerDatabaseAPI.Server.Models.Actors.COMPANY;
using CustomerDatabaseAPI.Server.Models.Actors.CALL;
using CustomerDatabaseAPI.Server.Models.General;
using CustomerDatabaseAPI.Server.Utilities;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
