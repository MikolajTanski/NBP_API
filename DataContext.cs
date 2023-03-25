using Microsoft.EntityFrameworkCore;
using NBPAPI.Models;

namespace NBPAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<GoldPrice> GoldPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            if (configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }
}
