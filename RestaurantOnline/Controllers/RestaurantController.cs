using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantOnline.Models;
using RestaurantOnline.OrdersRepository;

namespace RestaurantOnline.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RestaurantController : ControllerBase
	{
		private readonly IOrdersRepository<MenuPosition> _ordersRepository;

		public RestaurantController(IOrdersRepository<MenuPosition> ordersRepository)
		{
			_ordersRepository = ordersRepository;
		}

        [HttpGet("menu")]
        public IActionResult GetAllItemsFromMenu()
        {
            var result = _ordersRepository.GetMenu();
            var json = JsonConvert.SerializeObject(result);
            return Ok(json);
        }
    }
}
