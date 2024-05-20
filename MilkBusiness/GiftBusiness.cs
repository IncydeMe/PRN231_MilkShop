using Microsoft.EntityFrameworkCore;
using MilkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
	public class GiftBusiness
	{
		private readonly Net17112314MilkContext _context;

		public GiftBusiness()
		{
			if (_context == null)
				_context = new Net17112314MilkContext();
		}

		public async Task<IMilkResult> GetGiftList()
		{
			List<Gift> gifts = await _context.Gifts.ToListAsync();

			MilkResult result = new MilkResult(1, "Get gift list successfully", gifts);
			return result;
		}

		public async Task<IMilkResult> GetGiftById(int id)
		{
			Gift gift = await _context.Gifts.FindAsync(id);

			MilkResult result = new MilkResult(1, "Get gift successfully", gift);
			return result;
		}

		public async Task<IMilkResult> CreateGift(Gift gift)
		{
			_context.Gifts.Add(gift);
			await _context.SaveChangesAsync();

			MilkResult result = new MilkResult(1, "Create gift successfully", gift);
			return result;
		}

		public async Task<IMilkResult> UpdateGift(Gift gift)
		{
			_context.Gifts.Update(gift);
			await _context.SaveChangesAsync();

			MilkResult result = new MilkResult(1, "Update gift successfully", gift);
			return result;
		}

		public async Task<IMilkResult> DeleteGift(int id)
		{
			Gift gift = await _context.Gifts.FindAsync(id);
			_context.Gifts.Remove(gift);
			await _context.SaveChangesAsync();

			MilkResult result = new MilkResult(1, "Delete gift successfully", gift);
			return result;
		}

	}
}
