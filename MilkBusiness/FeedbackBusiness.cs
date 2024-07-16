using Microsoft.EntityFrameworkCore;
using MilkData.DTOs.Feedback;
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
                FeedbackId = createFeedbackDTO.FeedbackId,
                AccountId = createFeedbackDTO.AccountId,
                ProductId = createFeedbackDTO.ProductId,
                CreatedDate = createFeedbackDTO.CreatedDate,    
                UpdateDate = createFeedbackDTO.UpdateDate,
                Description = createFeedbackDTO.Description,
                FeedbackContent = createFeedbackDTO.FeedbackContent,
                Status = createFeedbackDTO.Status,
                Type = createFeedbackDTO.Type,
                Rating = createFeedbackDTO.Rating
            };

            await _unitOfWork.GetRepository<Feedback>().InsertAsync(feedback);


            MilkResult result = new MilkResult();
            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Status = 1;
                result.Message = "Create feedback successfully";
            }
            else
            {
                result.Status = -1;
                result.Message = "Create feedback failed";
            }
            return result;
        }

        public async Task<IMilkResult> GetFeedbackById(int feedbackId)
        {
            var feedback = await _unitOfWork.GetRepository<Feedback>()
                .SingleOrDefaultAsync(predicate: f => f.FeedbackId == feedbackId);
            return new MilkResult(feedback);
        }

        public async Task<IMilkResult> GetFeedbackOfProduct(int productId)
        {
            var feedbacks = await _unitOfWork.GetRepository<Feedback>()
                .GetListAsync(predicate: f => f.ProductId == productId);
            return new MilkResult(feedbacks);
        }

        public async Task<IMilkResult> GetAllFeedback()
        {
            var feedbackList = await _unitOfWork.GetRepository<Feedback>().GetListAsync();
            return new MilkResult(feedbackList);
        }

        public async Task<IMilkResult> UpdateFeedBack(FeedbackDTO feedback)
        {
            Feedback currentFeedback = await _unitOfWork.GetRepository<Feedback>()
                .SingleOrDefaultAsync(predicate: f => f.FeedbackId == feedback.FeedbackId);
            if (currentFeedback == null) return new MilkResult(-1, "Feedback cannot be found");
            else
            {
                currentFeedback.AccountId = feedback.AccountId;
                currentFeedback.ProductId = feedback.ProductId;
                currentFeedback.FeedbackContent = String.IsNullOrEmpty(feedback.FeedbackContent) ? currentFeedback.FeedbackContent : feedback.FeedbackContent;
                currentFeedback.Description = String.IsNullOrEmpty(feedback.Description) ? currentFeedback.Description : feedback.Description;
                currentFeedback.Status = String.IsNullOrEmpty(feedback.Status) ? currentFeedback.Status : feedback.Status;
                currentFeedback.Type = String.IsNullOrEmpty(feedback.Type) ? currentFeedback.Type : feedback.Type;
                currentFeedback.CreatedDate = feedback.CreatedDate;
                currentFeedback.UpdateDate = feedback.UpdateDate;
                currentFeedback.Rating = feedback.Rating;

                _unitOfWork.GetRepository<Feedback>().UpdateAsync(currentFeedback);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(currentFeedback);
        }

        public async Task<IMilkResult> DeleteFeedback(int id)
        {
            Feedback feedback = await _unitOfWork.GetRepository<Feedback>()
                .SingleOrDefaultAsync(predicate: f => f.FeedbackId == id);
            if (feedback == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Feedback>().DeleteAsync(feedback);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }
        #endregion
    }
}
