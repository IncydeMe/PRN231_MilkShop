using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Gifted;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers;

public class GiftedController : Controller
{
    private readonly GiftedBusiness giftedBusiness;
    public GiftedController()
    {
        giftedBusiness = new GiftedBusiness();
    }

    [Authorize]
    [HttpGet(ApiEndPointConstant.Gifted.GiftedsEndpoint)]
    [SwaggerOperation(Summary = "Get all Gifted")]
    public async Task<IActionResult> GetAllGifts()
    {
        var response = await giftedBusiness.GetAll();
        if (response.Status >= 0)
            return Ok(response.Data);
        else
            return BadRequest(response);
    }

    [Authorize]
    [HttpGet(ApiEndPointConstant.Gifted.GiftedsEndpoint)]
    [SwaggerOperation(Summary = "Get Gifted by its id")]
    public async Task<IActionResult> GetGiftedInfo(int id)
    {
        var response = await giftedBusiness.GetGiftedInfo(id);
        if (response.Status >= 0)
            return Ok(response.Data);
        else
            return BadRequest(response);
    }

    [Authorize(Roles = "staff")]
    [HttpPost(ApiEndPointConstant.Gifted.GiftedsEndpoint)]
    [SwaggerOperation(Summary = "Create a new Gifted")]
    public async Task<IActionResult> CreateGifted(GiftedDTO gifted)
    {
        var response = await giftedBusiness.CreateGifted(gifted);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [Authorize(Roles = "staff")]
    [HttpPut(ApiEndPointConstant.Gifted.GiftedsEndpoint)]
    [SwaggerOperation(Summary = "Update Gifted Info")]
    public async Task<IActionResult> UpdateGiftedInfo(int id, GiftedDTO gifted)
    {
        var response = await giftedBusiness.UpdateGifted(id, gifted);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }
    
    [Authorize(Roles = "staff")]
    [HttpPut(ApiEndPointConstant.Gifted.GiftedsEndpoint)]
    [SwaggerOperation(Summary = "Update Gifted Status")]
    public async Task<IActionResult> UpdateGiftedStatus(int id, string status)
    {
        var response = await giftedBusiness.ChangeGiftedStatus(id, status);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [Authorize(Roles = "staff")]
    [HttpDelete(ApiEndPointConstant.Gifted.GiftedsEndpoint)]
    [SwaggerOperation(Summary = "Delete Gifted")]
    public async Task<IActionResult> DeleteGifted(int id)
    {
        var response = await giftedBusiness.DeleteGifted(id);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }
}
