using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class OrderDTO
    {
        public class CreateOrderDTO
        {
            public Order Order { get; set; }
            public List<OrderDetail> OrderDetails { get; set; }
        }
    }
}
