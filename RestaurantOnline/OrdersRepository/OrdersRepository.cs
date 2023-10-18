using Azure.Core;
using FluentResults;
using Microsoft.EntityFrameworkCore;
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

        public Result<Cart> AddToCart(Guid cartId, Guid menuItem)
        {
            var cart = _context.Cart
                .Include(c => c.ToOrder)
                .First(c => c.Id == cartId);

            if (cart is null)
            {
                return Result.Fail<Cart>($"Couldn't find cart with id {cartId} in database ");
            }

            var item = _context.MenuPosition.Find(menuItem);

            if (cart.ToOrder is null) { cart.ToOrder = new List<MenuPosition>(); };
            cart.ToOrder.Add(item);

            _context.SaveChanges();
            return Result.Ok(cart);
        }

        public Result<Cart> CreateCart()
        {
            var cart = new Cart();

            _context.Cart.Add(cart);

            _context.SaveChanges();

            return Result.Ok(cart);
        }

        public List<MenuPosition> GetMenu()
		{
            var query = _context.MenuPosition;
            return query.ToList();
        }

        public Result<CustomerOrder> PlaceOrder(CustomerOrderRequset request)
        {
            var cart = _context.Cart
                .Include(c => c.ToOrder)
                .First(c => c.Id == request.CartId);

            if (cart is null || cart.ToOrder is null)
            {
                return Result.Fail<CustomerOrder>($"Couldn't find cart for client {request.ClientName} order");
            }

            var newOrder = new CustomerOrder()
            {
                Id = Guid.NewGuid(),
                ClientName = request.ClientName,
                City = request.City,
                Street = request.Street,
                Phone = request.Phone,
                Cart = cart
            };

            _context.CustomerOrder.Add(newOrder);
            _context.SaveChanges();

            return Result.Ok(newOrder);
        }

        public Result<CustomerOrder> GetOrder(Guid orderId)
        {
            var result =_context.CustomerOrder
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.ToOrder)
                .First(o => o.Id == orderId);

            return result is null ? Result.Fail($"Order with id: {orderId} doesn't exist") : Result.Ok(result);
        }
    }
}
