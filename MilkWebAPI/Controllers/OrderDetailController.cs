using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.DTOs.Order;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;
using static MilkData.DTOs.Order.OrderDetailDTO;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailBusiness _orderDetailBusiness;

        public OrderDetailController()
        {
            _orderDetailBusiness = new OrderDetailBusiness();
        }

        [HttpGet(ApiEndPointConstant.OrderDetail.OrderDetailsEndPoint)]
        [SwaggerOperation(Summary = "Get all Order Details")]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var response = await _orderDetailBusiness.GetAllOrderDetail();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.OrderDetail.OrderDetailEndPoint)]
        [SwaggerOperation(Summary = "Get Order Detail by its id")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var response = await _orderDetailBusiness.GetOrderDetailById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.OrderDetail.OrderDetailsEndPoint)]
        [SwaggerOperation(Summary = "Create a new Order Detail")]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailsInput input)
        {
            var response = await _orderDetailBusiness.CreateOrderDetail(input);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
