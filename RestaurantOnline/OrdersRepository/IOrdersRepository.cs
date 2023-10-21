using FluentResults;
using RestaurantOnline.Controllers.RequestModel;
using RestaurantOnline.Models;

namespace RestaurantOnline.OrdersRepository
{
	public interface IOrdersRepository<TEntity> where TEntity : class
	{
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> SaveAsync(CancellationToken cancellationToken = default);
        Task<bool> ClearAsync();
        List<MenuPosition> GetMenu();
        Result<CustomerOrder> PlaceOrder(CustomerOrderRequest request);
		Result<CustomerOrder> GetOrder(Guid id);
        Result<Cart> AddToCart(Guid cartId, Guid menuItem);
		Result<Cart> CreateCart();
	}
}
