using RestaurantOnline.Models;

namespace RestaurantOnline.OrdersRepository
{
	public interface IOrdersRepository
	{
		MenuPosition GetMenu();
		bool PlaceOrder(Guid id);
		void AddToCart(Cart cart);
	}
}
