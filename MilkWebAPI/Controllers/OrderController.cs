using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderBusiness _orderBusiness;

        public OrderController()
        {
            _orderBusiness = new OrderBusiness();
        }

        [HttpGet(ApiEndPointConstant.Order.OrdersEndPoint)]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderBusiness.GetAllOrders();
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Order.OrderEndPoint)]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderBusiness.GetOrderById(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Order.OrdersEndPoint)]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createOrder)
        {
            var response = await _orderBusiness.CreateOrder(createOrder);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
