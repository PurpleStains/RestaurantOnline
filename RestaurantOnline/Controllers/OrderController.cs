﻿using Microsoft.AspNetCore.Mvc;
using RestaurantOnline.Models;
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
        public ActionResult PlaceOrder([FromBody] CustomerOrderRequset order)
        {
            var result = _ordersRepository.PlaceOrder(order);
            return result.IsFailed ? BadRequest(result.Reasons) : Ok(result.Value);
        }

        [HttpGet("get")]
        public ActionResult PlaceOrder([FromQuery] Guid orderId)
        {
            var result = _ordersRepository.GetOrder(orderId);
            return result.IsFailed ? BadRequest(result.Reasons) : Ok(result.Value);
        }
    }
}
