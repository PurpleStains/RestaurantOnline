using FluentResults;
using RestaurantOnline.Controllers.RequestModel;
using RestaurantOnline.Models;

namespace RestaurantOnline.OrdersRepository
{
	public interface IOrdersRepository
	{
		List<MenuPosition> GetMenu();
        Result<CustomerOrder> PlaceOrder(CustomerOrderRequest request);
		Result<CustomerOrder> GetOrder(Guid id);
        Result<Cart> AddToCart(Guid cartId, Guid menuItem);
		Result<Cart> CreateCart();
	}
}
