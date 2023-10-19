using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using RestaurantOnline.Controllers;
using RestaurantOnline.Controllers.RequestModel;
using RestaurantOnline.Models;
using RestaurantOnline.OrdersRepository;
using FluentResults;

namespace RestarantOnlineTest.MenuTest
{
    [TestFixture]
    internal class RestaurantControllerTest
    {
        private Mock<IOrdersRepository> _ordersRepository;
        private RestaurantController _controller;

        [SetUp]
        public void SetUp()
        {
            _ordersRepository = new Mock<IOrdersRepository>();
            _ordersRepository.Setup(m => m.GetMenu()).Returns(TestDataHelper.GetFakeMenuPosition());

            _controller = new RestaurantController(_ordersRepository.Object);
        }

        [Test]
        public void ShouldReturnAllItemsFromMenu()
        {
            // Arrange
            var expectedResult = JsonConvert.SerializeObject(TestDataHelper.GetFakeMenuPosition());

            // Act
            var httpResult = _controller.GetAllItemsFromMenu();
            var okResult = httpResult as OkObjectResult;

            // Assert
            Assert.That(okResult.Value.ToString(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PlaceOrder_ValidOrder_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IOrdersRepository>();
            var controller = new OrderController(mockRepository.Object);
            var order = new CustomerOrderRequest();

            var newOrder = new CustomerOrder
            {
                Id = new Guid("CD133232-F1BA-4F94-B13E-0E4737E981C3")
            };
            
            var expectedResult = new OkObjectResult(newOrder);

            mockRepository.Setup(r => r.PlaceOrder(It.IsAny<CustomerOrderRequest>())).Returns(Result.Ok(newOrder));

            // Act
            var result = controller.PlaceOrder(order) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(newOrder));
        }

        [Test]
        public void GetOrder_ExistingOrderId_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IOrdersRepository>();
            var controller = new OrderController(mockRepository.Object);
            var orderId = new Guid("CD133232-F1BA-4F94-B13E-0E4737E981C3");

            var newOrder = new CustomerOrder
            {
                Id = orderId
            };
            var expectedResult = new OkObjectResult(newOrder);

            mockRepository.Setup(r => r.GetOrder(It.IsAny<Guid>())).Returns(newOrder);

            // Act
            var result = controller.GetOrder(orderId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(200, Is.EqualTo(result.StatusCode));
            Assert.That(newOrder, Is.EqualTo(result.Value));
        }
    }
}
