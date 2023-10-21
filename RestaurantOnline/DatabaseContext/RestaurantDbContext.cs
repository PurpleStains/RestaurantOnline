using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Models;

namespace RestaurantOnline.DatabaseContext
{
    public class RestaurantDbContext : DbContext
	{
        public RestaurantDbContext() { }
		public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

		public  DbSet<MenuPosition> MenuPosition { get; set; }
        public  DbSet<Cart> Cart { get; set; }
        public  DbSet<CustomerOrder> CustomerOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuPosition>().HasData(
                new MenuPosition
                {
                    Id = Guid.NewGuid(),
                    Name = "Cesar Salat",
                    Description = "Most popular salat on the world",
                    Price = 25
                },
                new MenuPosition
                {
                    Id = Guid.NewGuid(),
                    Name = "Spaghetti",
                    Description = "Most popular pasta on the world",
                    Price = 31
                },
                new MenuPosition
                {
                    Id = Guid.NewGuid(),
                    Name = "Carbonara",
                    Description = "Simple pasta with eggs, bacon and parmeggiano",
                    Price = 28
                },
                new MenuPosition
                {
                    Id = Guid.NewGuid(),
                    Name = "Coca-cola",
                    Description = "Soft drink",
                    Price = 5
                },
                new MenuPosition
                {
                    Id = Guid.NewGuid(),
                    Name = "Johannes",
                    Description = "Beer",
                    Price = 7
                }
            );
        }
    }
}
