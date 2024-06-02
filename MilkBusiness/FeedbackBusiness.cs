using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class FeedbackBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public FeedbackBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        #region Feedback
        public async Task<IMilkResult> CreateFeedback(FeedbackDTO createFeedbackDTO)
        {
            Feedback feedback = new Feedback
            {
                AccountId = createFeedbackDTO.AccountId,
                ProductId = createFeedbackDTO.ProductId,
                Content = createFeedbackDTO.Content,
                CreatedDate = DateTime.Now,
                Rating = createFeedbackDTO.Rating
            };

            await _unitOfWork.GetRepository<Feedback>().InsertAsync(feedback);
            

            MilkResult result = new MilkResult();
            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Data = GetFeedbackById(feedback.FeedbackId);
                result.Status = 1;
                result.Message = "Create feedback successfully";
            } else
            {
                result.Status = -1;
                result.Message = "Create feedback failed";
            }
            return result;
        }

        public async Task<IMilkResult> GetFeedbackById(int feedbackId)
        {
            var feedback = _unitOfWork.GetRepository<Feedback>().GetListAsync().Result.Where(x => x.FeedbackId == feedbackId);
            return new MilkResult(feedback);
        }

        public async Task<IMilkResult> GetAllFeedback()
        {
            var feedbackList = await _unitOfWork.GetRepository<Feedback>().GetListAsync();
            return new MilkResult(feedbackList);
        }
        #endregion
    }
}
