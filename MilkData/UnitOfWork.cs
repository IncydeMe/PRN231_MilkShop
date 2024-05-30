using MilkData.Base;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData
{
	public class UnitOfWork
	{
		private readonly Net17112314MilkContext _context;
		public UnitOfWork()
		{
			_context = new Net17112314MilkContext();
		}
		public GenericRepository<T> Repository<T>() where T : class
		{
			return new GenericRepository<T>();
		}
		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}
		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
