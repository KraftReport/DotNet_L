using Microsoft.EntityFrameworkCore;
using StockApi.Models;

namespace StockApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Stock> stocks { get; set; }
        public DbSet<Comment> comments { get; set; }
    } 
}
