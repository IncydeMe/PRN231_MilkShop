using Microsoft.EntityFrameworkCore;
using MilkData;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class GiftBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public GiftBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IMilkResult> GetGiftList()
        {
            var gifts = await _unitOfWork.GetRepository<Gift>().GetListAsync();

            return new MilkResult(1, "Get gift list successfully", gifts);
        }

        public async Task<IMilkResult> GetGiftById(int id)
        {
            Gift gift = await _unitOfWork.GetRepository<Gift>().SingleOrDefaultAsync(predicate: g => g.GiftId == id);

            MilkResult result = new MilkResult(1, "Get gift successfully", gift);
            return result;
        }

        public async Task<IMilkResult> CreateGift(Gift gift)
        {
            await _unitOfWork.GetRepository<Gift>().InsertAsync(gift);
            var res = await _unitOfWork.CommitAsync();

            if (res > 0)
            {
                return new MilkResult(1, "Create gift successfully", gift);
            }
            else
            {
                return new MilkResult();
            }

        }

        public async Task<IMilkResult> UpdateGift(Gift gift)
        {
            _unitOfWork.GetRepository<Gift>().UpdateAsync(gift);
            await _unitOfWork.CommitAsync();

            return new MilkResult(1, "Update gift successfully", gift);
        }

        public async Task<IMilkResult> DeleteGift(int id)
        {
            Gift gift = await _unitOfWork.GetRepository<Gift>().SingleOrDefaultAsync(predicate: g => g.GiftId == id);

            if (gift == null)
            {
                return new MilkResult();
            }
            else
            {
                _unitOfWork.GetRepository<Gift>().DeleteAsync(gift);
                await _unitOfWork.CommitAsync();

                return new MilkResult(1, "Delete gift successfully", gift);
            }
        }
    }
}
