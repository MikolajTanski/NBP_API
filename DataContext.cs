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
    }
}
