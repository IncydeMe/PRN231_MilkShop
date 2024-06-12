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
        public int OrderId { get; set; }

        public int AccountId { get; set; }

        public Guid VoucherCode { get; set; }

        public float TotalPrice { get; set; }

        public string Status { get; set; } = null!;

        public string? HttpMethod { get; set; }

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
