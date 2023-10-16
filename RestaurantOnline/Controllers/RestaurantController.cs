using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.OrdersRepository;

namespace RestaurantOnline.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : ControllerBase
	{
		private readonly IOrdersRepository _ordersRepository;

		public RestaurantController(IOrdersRepository ordersRepository)
		{
			_ordersRepository = ordersRepository;
		}

		[HttpGet("menu")]
		public ActionResult GetAllPositionsFromMenu()
		{
			return Ok(_ordersRepository.GetMenu().Description);
		}
    }
}
