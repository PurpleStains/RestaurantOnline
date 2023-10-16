using Microsoft.EntityFrameworkCore;
using RestaurantOnline.Models;

namespace RestaurantOnline.DatabaseContext
{
	public class RestaurantDbContext : DbContext
	{
		public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

		public DbSet<MenuPosition> MenuPosition { get; set; }
	}
}
