using Microsoft.EntityFrameworkCore;
using MilkData;
using MilkData.DAO;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
	public class VoucherBusiness
	{
		private readonly VoucherDAO _voucherDAO;

		public VoucherBusiness()
		{
			_voucherDAO = new VoucherDAO();
		}

		public async Task<IMilkResult> GetVoucherList()
		{
			var vouchers = await _voucherDAO.GetVoucherListAsync();
			try
			{
				if (vouchers == null)
				{
					return new MilkResult(-1, "Get voucher list failed", null);
				}
				else
				{
					return new MilkResult(1, "Get voucher list successfully", vouchers);
				}
			}
			catch (Exception ex)
			{
				return new MilkResult(-1, ex.Message, null);
			}
		}

		public async Task<IMilkResult> GetVoucherById(int id)
		{
			var voucher = await _voucherDAO.GetVoucherById(id);
			try
			{
				if (voucher == null)
				{
					return new MilkResult(-1, "Get voucher failed", null);
				}
				else
				{
					return new MilkResult(1, "Get voucher successfully", voucher);
				}
			}
			catch (Exception ex)
			{
				return new MilkResult(-1, ex.Message, null);
			}
		}

		public async Task<IMilkResult> CreateVoucher(Voucher voucher)
		{
			try
			{
				await _voucherDAO.CreateVoucherAsync(voucher);
				return new MilkResult(1, "Create voucher successfully", voucher);
			}
			catch (Exception ex)
			{
				return new MilkResult(-1, ex.Message, null);
			}
		}

		public async Task<IMilkResult> UpdateVoucher(Voucher voucher)
		{
			try
			{
				await _voucherDAO.UpdateVoucherAsync(voucher);
				return new MilkResult(1, "Update voucher successfully", voucher);
			}
			catch (Exception ex)
			{
				return new MilkResult(-1, ex.Message, null);
			}
		}

		public async Task<IMilkResult> DeleteVoucher(int id)
		{
			var voucher = await _voucherDAO.GetVoucherById(id);
			try
			{
				if (voucher == null)
				{
					return new MilkResult(-1, "Delete voucher failed", null);
				}
				else
				{
					_voucherDAO.DeleteVoucher(voucher);
					return new MilkResult(1, "Delete voucher successfully", voucher);
				}
			}
			catch (Exception ex)
			{
				return new MilkResult(-1, ex.Message, null);
			}
		}
	}
}
