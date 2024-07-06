using Microsoft.EntityFrameworkCore;
using MilkData;
using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness;

public class VoucherBusiness
{
    //private readonly UnitOfWork _unitOfWork;

    //public VoucherBusiness()
    //{
    //    _unitOfWork ??= new UnitOfWork();
    //}

    //public async Task<IMilkResult> GetVoucherList()
    //{
    //    var vouchers = await _unitOfWork.GetRepository<Voucher>().GetListAsync();

    //    return new MilkResult(1, "Get voucher list successfully", vouchers);
    //}

    //public async Task<IMilkResult> GetVoucherById(Guid id)
    //{
    //    Voucher voucher = await _unitOfWork.GetRepository<Voucher>().SingleOrDefaultAsync(predicate: v => v.VoucherId.Equals(id));

    //    MilkResult result = new MilkResult(1, "Get voucher successfully", voucher);
    //    return result;
    //}

    //public async Task<IMilkResult> CreateVoucher(VoucherDTO voucher)
    //{
    //    if(!DateCompare(voucher.StartDate, voucher.EndDate)) return new MilkResult(-1, "Start date cannot smaller than End date");

    //    Voucher newVoucher = new Voucher()
    //    {
    //        VoucherId = voucher.VoucherId,
    //        Value = voucher.Value,
    //        EndDate = voucher.EndDate,
    //        StartDate = voucher.StartDate,
    //    };

    //    await _unitOfWork.GetRepository<Voucher>().InsertAsync(newVoucher);
    //    var res = await _unitOfWork.CommitAsync();

    //    if (res > 0)
    //    {
    //        return new MilkResult(1, "Create voucher successfully", newVoucher);
    //    }
    //    else
    //    {
    //        return new MilkResult();
    //    }
    //}

    //public async Task<IMilkResult> UpdateVoucher(VoucherDTO voucher)
    //{
    //    if (!DateCompare(voucher.StartDate, voucher.EndDate)) return new MilkResult(-1, "Start date cannot smaller than End date");

    //    Voucher currentVoucher = await _unitOfWork.GetRepository<Voucher>()
    //        .SingleOrDefaultAsync(predicate: v => v.VoucherId == voucher.VoucherId);

    //    if (currentVoucher == null) return new MilkResult(-1, "Account cannot be found");
    //    else
    //    {
    //        currentVoucher.Value = voucher.Value;
    //        currentVoucher.EndDate = voucher.EndDate;
    //        currentVoucher.StartDate = voucher.StartDate;

    //        _unitOfWork.GetRepository<Voucher>().UpdateAsync(currentVoucher);
    //        await _unitOfWork.CommitAsync();
    //    }

    //    return new MilkResult(currentVoucher);
    //}

    //public async Task<IMilkResult> DeleteVoucher(Guid id)
    //{
    //    Voucher voucher = await _unitOfWork.GetRepository<Voucher>().SingleOrDefaultAsync(predicate: v => v.VoucherId.Equals(id));

    //    if (voucher == null)
    //    {
    //        return new MilkResult();
    //    }
    //    else
    //    {
    //        _unitOfWork.GetRepository<Voucher>().DeleteAsync(voucher);
    //        await _unitOfWork.CommitAsync();

    //        return new MilkResult(1, "Delete voucher successfully", voucher);
    //    }
    //}


    //private bool DateCompare(DateTime date1, DateTime date2)
    //{
    //    return date1 < date2;
    //}
}
