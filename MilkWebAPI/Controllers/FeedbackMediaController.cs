using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class FeedbackMediaController : ControllerBase
    {
        private readonly FeedbackMediaBusiness _feedbackMediaBusiness;
        public FeedbackMediaController()
        {
            _feedbackMediaBusiness = new FeedbackMediaBusiness();
        }

        [HttpGet(ApiEndPointConstant.FeedbackMedia.FeedbackMediaEndPoint)]
        public async Task<IActionResult> GetAllFeedbackMedia()
        {
            var response = await _feedbackMediaBusiness.GetAllFeMedia();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response.Message);
        }

        [HttpGet(ApiEndPointConstant.FeedbackMedia.FeedbacMediumkEndPoint)]
        public async Task<IActionResult> GetAllFeedbackMedia(int id)
        {
            var response = await _feedbackMediaBusiness.GetFeMedaiInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.FeedbackMedia.FeedbackMediaEndPoint)]
        public async Task<IActionResult> CreateFeedbackMedia(FeedbackMediaDTO feedbackMedia)
        {
            var response = await _feedbackMediaBusiness.CreateFeMedia(feedbackMedia);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.FeedbackMedia.FeedbacMediumkEndPoint)]
        public async Task<IActionResult> UpdateFeedbackMedia(int id, FeedbackMediaDTO feedbackMedia)
        {
            var response = await _feedbackMediaBusiness.UpdateFeMediaInfo(feedbackMedia);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.FeedbackMedia.FeedbacMediumkEndPoint)]
        public async Task<IActionResult> DeleteFeedbackMedia(int id)
        {
            var response = await _feedbackMediaBusiness.DeleteFeedbackMedia(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
