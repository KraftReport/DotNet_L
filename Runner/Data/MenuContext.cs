using Microsoft.EntityFrameworkCore;
using Runner.Models;

namespace Runner.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiskIngridients>().HasKey(di => new
            {
                di.DiskId,
                di.IngridientId
            });

            modelBuilder.Entity<DiskIngridients>()
                .HasOne(d => d.Dish)
                .WithMany(di => di.DishIngredients)
                .HasForeignKey(d => d.DiskId);

            modelBuilder.Entity<DiskIngridients>()
                .HasOne(d => d.Ingridient)
                .WithMany(di => di.DiskIngridients)
                .HasForeignKey(d => d.IngridientId);

            modelBuilder.Entity<Dish>().HasData(
    new Dish { Id = 1, Name = "Margheritta", Price = 7.50, ImageUrl = "https://cdn.shopify.com/s/files/1/0205/9582/articles/20220211142347-margherita-9920_ba86be55-674e-4f35-8094-2067ab41a671.jpg?crop=center&height=915&v=1644590192&width=1200" }
    );
            modelBuilder.Entity<Ingridients>().HasData(
                new Ingridients { Id = 1, Name = "Tomato Sauce" },
                new Ingridients { Id = 2, Name = "Mozzarella" }
                );
            modelBuilder.Entity<DiskIngridients>().HasData(
                new DiskIngridients { DiskId = 1, IngridientId = 1 },
                new DiskIngridients { DiskId = 1, IngridientId = 2 }
                );

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Dish> Dish { get; set; }
        public DbSet<Ingridients> Ingredient { get; set; }
        public DbSet<DiskIngridients> DiskIngridients { get; set; }
    }
}
