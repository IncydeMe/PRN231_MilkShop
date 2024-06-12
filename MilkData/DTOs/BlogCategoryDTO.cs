using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
	public class BlogCategoryDTO
	{
		public int BlogCategoryId { get; set; }

		public string BlogCategoryName { get; set; } = null!;
		
		public string? HttpMethod { get; set; }
	}
}
