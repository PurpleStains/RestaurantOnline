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
	}
}
