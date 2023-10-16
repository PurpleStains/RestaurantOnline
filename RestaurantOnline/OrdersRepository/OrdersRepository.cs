using RestaurantOnline.DatabaseContext;
using RestaurantOnline.Models;

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

        public MenuPosition GetMenu()
		{
			var test = _context;
			
			return new MenuPosition()
			{
				Id = Guid.NewGuid(),
				Name = "Cesar Salat",
				Description = "Classic position for all lovers of salats",
				Price = 24.5
			};
		}

        public bool PlaceOrder(Guid id)
        {
            var order = _context.Find<CustomerOrder>(id);
			if (order is null) return false;

			return true;
        }
    }
}
