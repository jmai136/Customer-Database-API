using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerDatabaseAPI.Server.Models.Actors.Recipients;

    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext (DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; } = default!;
    }
