using Microsoft.EntityFrameworkCore;

namespace Currency.DAL.DataAccess
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Currency.DAL.Models.Currency> Currencies { get; set; }
    }
}
