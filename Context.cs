using Database;
using APIProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject
{
    public class Context : DbContext
    {
        public static IConfigurationRoot Configuration { get; set; }

        public Context()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            // define builder
            Configuration = builder.Build();
        }
        public DbSet<UsersTable> Users { get; set; }
        public DbSet<LanguangesTable> Languanges { get; set; }
        public DbSet<CurrenciesTable> Currencies { get; set; }
        public DbSet<DestinationsTable> Destinations { get; set; }
        public DbSet<MeasurementsTable> Measurements { get; set; }
        public DbSet<PurchaseOrdersTable> PurchaseOrders { get; set; }
        public DbSet<BillsTable> Bills { get; set; }
        public DbSet<BillDetailsTable> BillDetails { get; set; }
        public DbSet<SPUserCount> SPUserCounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Localhost;database=Latihan.API;User Id=Sa;Password=pakizin87;MultipleActiveResultSets=True");
        }
    }
}
