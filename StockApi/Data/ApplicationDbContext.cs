using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockApi.Models;

namespace StockApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Stock> stocks { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Portfolio> portfolio { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Portfolio>(p => p.HasKey(x => new { x.AppUserId, x.StockId }));
            builder.Entity<Portfolio>()
                .HasOne(p => p.AppUser)
                .WithMany(p => p.portfolios)
                .HasForeignKey(p => p.AppUserId);
            builder.Entity<Portfolio>()
                .HasOne(p => p.Stock)
                .WithMany(p => p.portfolios)
                .HasForeignKey(p => p.StockId);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }

}
