using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Models;
using RestaurantOnline.OrdersRepository;

namespace RestaurantOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IOrdersRepository<Cart> _ordersRepository;

        public CartController(IOrdersRepository<Cart> orderRepository)
        {
            _ordersRepository = orderRepository;
        }

        [HttpPost("create")]
        public ActionResult CreateCart()
        {
            var result = _ordersRepository.CreateCart();
            return result.IsFailed ? BadRequest(result.Reasons) : Ok(result);
        }
        [HttpPost("add")]
        public ActionResult AddToCart([FromQuery] Guid cartId, Guid menuItem)
        {
            var result = _ordersRepository.AddToCart(cartId, menuItem);

            return result.IsFailed ? BadRequest(result.Reasons) : Ok(result.Value);
        }
    }
}
