using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;
using Payment.Domain.VNPay.Response;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderBusiness.GetAllOrders();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Order.OrderEndPoint)]
        [SwaggerOperation(Summary = "Get Order by its id")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderBusiness.GetOrderById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Order.OrdersEndPoint)]
        [SwaggerOperation(Summary = "Create a new Order")]
        public async Task<IActionResult> CreateOrder(OrderDTO createOrder)
        {
            var response = await _orderBusiness.CreateOrder(createOrder);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Payment Response")]
        public async Task<IActionResult> PaymentResponse([FromQuery] VNPayResponse response)
        {
            try
            {
                var result = await _orderBusiness.CheckPaymentResponse(response);
                PaymentDTO.PaymentReturnResponse paymentResponse = (PaymentDTO.PaymentReturnResponse)result.Data;
                var order = await _orderBusiness.GetOrderById(paymentResponse.OrderId);
                int accountId = ((Order)order.Data).AccountId;

                if (paymentResponse.PaymentStatus.Equals("Success"))
                {
                    await _orderBusiness.ChangeOrderStatus(paymentResponse.OrderId, "Paid");
                }

                PaymentDTO.PaymentReturnResponse paymentReturnResponse = new PaymentDTO.PaymentReturnResponse
                {
                    OrderId = paymentResponse.OrderId,
                    PaymentStatus = paymentResponse.PaymentStatus,
                    PaymentMessage = paymentResponse.PaymentMessage,
                    Amount = paymentResponse.Amount
                };
                //redirect or ok?
                return Ok(paymentReturnResponse);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(BadHttpRequestException))
                {
                    return BadRequest(ex.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
