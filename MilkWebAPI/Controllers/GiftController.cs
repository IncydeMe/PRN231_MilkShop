//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using MilkBusiness;
//using MilkData;
//using MilkData.Models;
//using MilkWebAPI.Constants;

//namespace MilkWebAPI.Controllers
//{
//	[ApiController]
//	public class GiftController : ControllerBase
//	{
//		private readonly GiftBusiness _giftBusiness;
//		public GiftController()
//		{
//			_giftBusiness = new GiftBusiness();
//		}

//		[HttpGet(ApiEndPointConstant.Gift.GiftsEndpoint)]
//		public async Task<IActionResult> GetGiftList()
//		{
//			var response = await _giftBusiness.GetGiftList();
//			if (response.Status >= 0)
//				return Ok(response);
//			else
//				return BadRequest(response);
//		}

//		[HttpGet(ApiEndPointConstant.Gift.GiftEndpoint)]
//		public async Task<IActionResult> GetGiftById(int giftId)
//		{
//			var response = await _giftBusiness.GetGiftById(giftId);
//			if (response.Status >= 0)
//				return Ok(response);
//			else
//				return BadRequest(response);
//		}

//		[HttpPost(ApiEndPointConstant.Gift.GiftsEndpoint)]
//		public async Task<IActionResult> CreateGift(Gift gift)
//		{
//			var response = await _giftBusiness.CreateGift(gift);
//			if (response.Status >= 0)
//				return Ok(response);
//			else
//				return BadRequest(response);
//		}

//		[HttpPut(ApiEndPointConstant.Gift.GiftEndpoint)]
//		public async Task<IActionResult> UpdateGift(Gift gift)
//		{
//			var response = await _giftBusiness.UpdateGift(gift);
//			if (response.Status >= 0)
//				return Ok(response);
//			else
//				return BadRequest(response);
//		}

//		[HttpDelete(ApiEndPointConstant.Gift.GiftEndpoint)]
//		public async Task<IActionResult> DeleteGift(int id)
//		{
//			var response = await _giftBusiness.DeleteGift(id);
//			if (response.Status >= 0)
//				return Ok(response);
//			else
//				return BadRequest(response);
//		}

//	}
//}
