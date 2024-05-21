using MilkData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DAO
{
	public class VoucherDAO: BaseDAO<Voucher>
	{
		public List<Voucher> GetVoucherList()
		{
			return GetAll();
		}
		public async Task<List<Voucher>> GetVoucherListAsync()
		{
			return await GetAllAsync();
		}
		public async Task<Voucher> GetVoucherById(int id)
		{
			return await _dbSet.FindAsync(id);
		}
		public void CreateVoucher(Voucher voucher)
		{
			Create(voucher);
		}
		public async Task<int> CreateVoucherAsync(Voucher voucher)
		{
			return await CreateAsync(voucher);
		}
		public void UpdateVoucher(Voucher voucher)
		{
			Update(voucher);
		}
		public async Task UpdateVoucherAsync(Voucher voucher)
		{
			await UpdateAsync(voucher);
		}
		public bool DeleteVoucher(Voucher voucher)
		{
			return Remove(voucher);
		}
		
	}
}
