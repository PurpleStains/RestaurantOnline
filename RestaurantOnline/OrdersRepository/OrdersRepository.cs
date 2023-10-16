using RestaurantOnline.DatabaseContext;
using RestaurantOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantOnline.OrdersRepository
{
	public class OrdersRepository : IOrdersRepository
	{
		private readonly RestaurantDbContext _context;

		public OrdersRepository(RestaurantDbContext context)
		{
			_context = context;
		}

        public void AddToCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public List<MenuPosition> GetMenu()
		{
            var query = _context.MenuPosition;
            return query.ToList();
        }

        public bool PlaceOrder(Guid id)
        {
            var order = _context.Find<CustomerOrder>(id);
			if (order is null) return false;

			return true;
        }
    }
}
