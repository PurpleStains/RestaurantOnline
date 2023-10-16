using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOnline.OrdersRepository;
using System.Text.Json.Serialization;

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
			var result = _ordersRepository.GetMenu();
			var json = JsonConvert.SerializeObject(result);
			return Ok(json);
		}
    }
}
