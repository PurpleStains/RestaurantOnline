using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestaurantOnline.Models;
using RestaurantOnline.OrdersRepository;

namespace RestarantOnlineTest
{
    public class MenuTests : TestBase
    {
        public MenuTests() : base(new TestWebApplicationFactory<Program>())
        {
        }

        [Test]
        public async Task Get_Menu_Should_Return_Valid_Data()
        {
            // Arrange 
            var expectedResult = await CreateMenuAsync();
            var repository = ServiceProvider.GetService<IOrdersRepository<MenuPosition>>();

            // Act
            var url = $"restaurant/menu";
            var response = await Client.GetAsync(url);
            var result = await GetObjectFromResponse<List<MenuPosition>>(response);

            // Assert
            expectedResult.Should().BeEquivalentTo(result);
        }
    }
}
