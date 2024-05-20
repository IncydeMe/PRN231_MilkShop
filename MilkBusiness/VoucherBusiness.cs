using Microsoft.EntityFrameworkCore;
using MilkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
	public class VoucherBusiness
	{
		private readonly Net17112314MilkContext _context;

		public VoucherBusiness()
		{
			if (_context == null)
				_context = new Net17112314MilkContext();
		}

		public async Task<IMilkResult> GetVoucherList()
		{
			List<Voucher> vouchers = await _context.Vouchers.ToListAsync();

			MilkResult result = new MilkResult(1, "Get voucher list successfully", vouchers);
			return result;
		}

		public async Task<IMilkResult> GetVoucherById(int id)
		{
			Voucher voucher = await _context.Vouchers.FindAsync(id);

			MilkResult result = new MilkResult(1, "Get voucher successfully", voucher);
			return result;
		}

		public async Task<IMilkResult> CreateVoucher(Voucher voucher)
		{
			_context.Vouchers.Add(voucher);
			await _context.SaveChangesAsync();

			MilkResult result = new MilkResult(1, "Create voucher successfully", voucher);
			return result;
		}

		public async Task<IMilkResult> UpdateVoucher(Voucher voucher)
		{
			_context.Vouchers.Update(voucher);
			await _context.SaveChangesAsync();

			MilkResult result = new MilkResult(1, "Update voucher successfully", voucher);
			return result;
		}

		public async Task<IMilkResult> DeleteVoucher(int id)
		{
			Voucher voucher = await _context.Vouchers.FindAsync(id);
			_context.Vouchers.Remove(voucher);
			await _context.SaveChangesAsync();

			MilkResult result = new MilkResult(1, "Delete voucher successfully", voucher);
			return result;
		}
	}
}
