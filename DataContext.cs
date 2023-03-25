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
            var factory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(factory);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
