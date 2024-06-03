using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackBusiness _feedbackBusiness;

        public FeedbackController()
        {
            _feedbackBusiness = new FeedbackBusiness();
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbacksEndPoint)]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var response = await _feedbackBusiness.GetAllFeedback();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbackEndPoint)]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            var response = await _feedbackBusiness.GetFeedbackById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Feedback.FeedbacksEndPoint)]
        public async Task<IActionResult> CreateFeedback(FeedbackDTO createFeedback)
        {
            var response = await _feedbackBusiness.CreateFeedback(createFeedback);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Feedback.FeedbackEndPoint)]
        public async Task<IActionResult> UpdateFeedback(int id, FeedbackDTO feedback)
        {
            var response = await _feedbackBusiness.UpdateFeedBack(feedback);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Feedback.FeedbackEndPoint)]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var response = await _feedbackBusiness.DeleteFeedback(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
