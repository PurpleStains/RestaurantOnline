using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.OrdersRepository;

namespace RestaurantOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;

        public CartController(IOrdersRepository orderRepository)
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
