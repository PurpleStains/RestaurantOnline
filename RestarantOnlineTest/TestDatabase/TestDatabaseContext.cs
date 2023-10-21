using Microsoft.EntityFrameworkCore;
using RestaurantOnline.DatabaseContext;

namespace RestarantOnlineTest.TestDatabase
{
    internal class TestDatabaseContext : RestaurantDbContext
    {

        public TestDatabaseContext(DbContextOptions<RestaurantDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(TestWebApplicationFactory<Program>.ConnectionString);
        }
    }
}
