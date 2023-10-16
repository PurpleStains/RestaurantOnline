using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.OrdersRepository;

namespace RestaurantOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrderController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpPost("place")]
        public ActionResult PlaceOrder(Guid id)
        {
            _ordersRepository.PlaceOrder(id);

            return Ok();
        }
    }
}
