using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
	public class CreateOrderDTO
	{
		public int AccountId { get; set; }

		public Guid VoucherCode { get; set; }

		public float TotalPrice { get; set; }

		public string Status { get; set; } = null!;

		public List<OrderDetail> OrderDetails { get; set; }
	}
}
