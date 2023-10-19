using Moq;
using Moq.EntityFrameworkCore;
using RestaurantOnline.Controllers;
using RestaurantOnline.DatabaseContext;
using RestaurantOnline.OrdersRepository;

namespace RestarantOnlineTest.Mocks
{
    internal class MockOrdersRepository
    {

        public static RestaurantController GetOrdersRepositoryMock()
        {
            var restaurantDbContext = GetRestaurantDbContextMock();
            var mock = new Mock<OrdersRepository>(restaurantDbContext.Object);
            var test = new RestaurantController(mock.Object);
            return test;
        }

        public static Mock<RestaurantDbContext> GetRestaurantDbContextMock()
        {
            var mock = new Mock<RestaurantDbContext>();

            mock.Setup(x => x.MenuPosition)
                .ReturnsDbSet(TestDataHelper.GetFakeMenuPosition());

            return mock;
        }
    }
}
