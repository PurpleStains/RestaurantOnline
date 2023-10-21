using FluentAssertions;
using RestaurantOnline.Models;
using System.Net;

namespace RestarantOnlineTest
{
    [TestFixture]
    internal class CartTest : TestBase
    {
        public CartTest() : base(new TestWebApplicationFactory<Program>())
        {
        }

        [Test]
        public async Task Should_Create_Cart()
        {

            // Act
            var url = $"cart/create";
            var content = new StringContent("Test");
            var response = await Client.PostAsync(url, content);
            
            var result = await GetObjectFromResponse<Cart>(response);
            // Assert
            result.Should().BeOfType(typeof(Cart));
            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task Should_Add_Item_To_Cart()
        {
            // Arrange
            var menuItem = TestDataHelper.GetFakeMenuPosition().First();
            await CreateMenuAsync();
            var cart = await CreateCartAsync();
            cart.ToOrder = new() { menuItem };

            // Act
            var url = $"cart/add/?cartId={cart.Id}&menuItem={menuItem.Id}";
            var response = await Client.PostAsync(url, new StringContent(""));
            var result = await GetObjectFromResponse<Cart>(response);

            // Assert
            result.Id.Should().Be(cart.Id);
            result.ToOrder.Should().BeEquivalentTo(cart.ToOrder);
            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
        }
    }
}
