using Microsoft.EntityFrameworkCore;

namespace RemittanceAPI.Entity
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}