using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Order;
using MilkData.Models;
using MilkData.VNPay.Response;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;
using static MilkData.DTOs.Order.OrderDTO;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly OrderBusiness _orderBusiness;

        public PaymentController()
        {
            _orderBusiness = new OrderBusiness();
        }

        [HttpGet(ApiEndPointConstant.Payment.PaymentReturnEndPoint)]
        [SwaggerOperation(Summary = "Payment Response")]
        public async Task<IActionResult> PaymentResponse([FromQuery] VNPayResponse response)
        {
            try
            {
                var result = await _orderBusiness.CheckPaymentResponse(response);
                PaymentDTO.PaymentReturnResponse paymentResponse = (PaymentDTO.PaymentReturnResponse)result.Data;
                var order = await _orderBusiness.GetOrderById(paymentResponse.OrderId);
                Guid accountId = ((GetSingleOrder)order.Data).AccountId;

                if (paymentResponse.PaymentStatus.Equals("Success"))
                {
                    await _orderBusiness.ChangeOrderStatus(paymentResponse.OrderId, "Delivering");
                }
                else
                {
                    await _orderBusiness.ChangeOrderStatus(paymentResponse.OrderId, "Failed");
                }

                //PaymentDTO.PaymentReturnResponse paymentReturnResponse = new PaymentDTO.PaymentReturnResponse
                //{
                //    OrderId = paymentResponse.OrderId,
                //    PaymentStatus = paymentResponse.PaymentStatus,
                //    PaymentMessage = paymentResponse.PaymentMessage,
                //    Amount = paymentResponse.Amount
                //};
                ////redirect or ok?
                //return Ok(paymentReturnResponse);
                string returnUrl = $"http://localhost:3000/payment?paymentStatus={paymentResponse.PaymentStatus}&message={paymentResponse.PaymentMessage}&amount={paymentResponse.Amount}";
                return Redirect(returnUrl);

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
