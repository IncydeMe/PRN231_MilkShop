﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers;

[ApiController]
public class GiftController : ControllerBase
{
	//private readonly GiftBusiness _giftBusiness;
	//public GiftController()
	//{
	//	_giftBusiness = new GiftBusiness();
	//}

	//[HttpGet(ApiEndPointConstant.Gift.GiftsEndpoint)]
	//[SwaggerOperation(Summary = "Get all gifts")]
	//public async Task<IActionResult> GetGiftList()
	//{
	//	var response = await _giftBusiness.GetGiftList();
	//	if (response.Status >= 0)
	//		return Ok(response.Data);
	//	else
	//		return BadRequest(response);
	//}

	//[HttpGet(ApiEndPointConstant.Gift.GiftEndpoint)]
	//[SwaggerOperation(Summary = "Get gift by its id")]
	//public async Task<IActionResult> GetGiftById(int id)
	//{
	//	var response = await _giftBusiness.GetGiftById(id);
	//	if (response.Status >= 0)
	//		return Ok(response.Data);
	//	else
	//		return BadRequest(response);
	//}

	//[HttpPost(ApiEndPointConstant.Gift.GiftsEndpoint)]
	//[SwaggerOperation(Summary = "Create a new gift")]
	//public async Task<IActionResult> CreateGift(GiftDTO gift)
	//{
	//	var response = await _giftBusiness.CreateGift(gift);
	//	if (response.Status >= 0)
	//		return Ok(response);
	//	else
	//		return BadRequest(response);
	//}

	//[HttpPut(ApiEndPointConstant.Gift.GiftEndpoint)]
	//[SwaggerOperation(Summary = "Update a gift")]
	//public async Task<IActionResult> UpdateGift(int id, GiftDTO gift)
	//{
	//	var response = await _giftBusiness.UpdateGift(gift);
	//	if (response.Status >= 0)
	//		return Ok(response);
	//	else
	//		return BadRequest(response);
	//}

	//[HttpDelete(ApiEndPointConstant.Gift.GiftEndpoint)]
	//[SwaggerOperation(Summary = "Delete a gift")]
	//public async Task<IActionResult> DeleteGift(int id)
	//{
	//	var response = await _giftBusiness.DeleteGift(id);
	//	if (response.Status >= 0)
	//		return Ok(response);
	//	else
	//		return BadRequest(response);
	//}
}
