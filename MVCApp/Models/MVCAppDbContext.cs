using Microsoft.EntityFrameworkCore;

namespace MVCApp.Models
{
    public class MVCAppDbContext : DbContext
    {

        public DbSet<Expense> Expense { get; set; }

        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options) : base(options) { }

    }
}
