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
	public class VoucherBusiness
	{
        private readonly UnitOfWork _unitOfWork;

        public VoucherBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IMilkResult> GetVoucherList()
        {
            var vouchers = await _unitOfWork.GetRepository<Voucher>().GetListAsync();

            return new MilkResult(1, "Get voucher list successfully", vouchers);
        }

        public async Task<IMilkResult> GetVoucherById(Guid id)
        {
            Voucher voucher = await _unitOfWork.GetRepository<Voucher>().SingleOrDefaultAsync(predicate: v => v.VoucherId.Equals(id));

            MilkResult result = new MilkResult(1, "Get voucher successfully", voucher);
            return result;
        }

        public async Task<IMilkResult> CreateVoucher(Voucher voucher)
        {
            await _unitOfWork.GetRepository<Voucher>().InsertAsync(voucher);
            var res = await _unitOfWork.CommitAsync();

            if (res > 0)
            {
                return new MilkResult(1, "Create voucher successfully", voucher);
            }
            else
            {
                return new MilkResult();
            }
        }

        public async Task<IMilkResult> UpdateVoucher(Voucher voucher)
        {
            _unitOfWork.GetRepository<Voucher>().UpdateAsync(voucher);
            await _unitOfWork.CommitAsync();

            return new MilkResult(1, "Update voucher successfully", voucher);
        }

        public async Task<IMilkResult> DeleteVoucher(Guid id)
        {
            Voucher voucher = await _unitOfWork.GetRepository<Voucher>().SingleOrDefaultAsync(predicate: v => v.VoucherId.Equals(id));

            if (voucher == null)
            {
                return new MilkResult();
            }
            else
            {
                _unitOfWork.GetRepository<Voucher>().DeleteAsync(voucher);
                await _unitOfWork.CommitAsync();

                return new MilkResult(1, "Delete voucher successfully", voucher);
            }
        }
    }
}
