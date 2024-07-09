using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MilkData.DTOs.Order.OrderDetailDTO;

namespace MilkData.DTOs.Order
{
    public class OrderDTO
    {
        public class CreateOrder
        {
            public int? VoucherId { get; set; }

            public Guid AccountId { get; set; }

            public decimal OrderPrice { get; set; }

        }

        public class GetSingleOrder
        {
            public int OrderId { get; set; }

            public int? VoucherId { get; set; }

            public Guid AccountId { get; set; }

            public string Status { get; set; }

            public decimal? OrderPrice { get; set; }

            public List<GetOrderDetail> OrderDetails { get; set; }
        }
        //public class CreateOrderDTO
        //{
        //    //Order
        //    public int AccountId { get; set; }

        //    public Guid VoucherCode { get; set; }

        //    public float TotalPrice { get; set; }

        //    public string Status { get; set; } = null!;


        //    //OrderDetail
        //    public List<CreateOrderDetailDTO> OrderDetails { get; set; }
        //}

        //public class CreateOrderDetailDTO
        //{

        //    public int Quantity { get; set; }

        //    public int ProductId { get; set; }
        //}
    }
}
