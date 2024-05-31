using Microsoft.EntityFrameworkCore;
using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class OrderBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        #region Order

        public async Task<IMilkResult> GetAllOrders()
        {
            var ordersList = await _unitOfWork.GetRepository<Order>().GetListAsync();
            return new MilkResult(ordersList);
        }

        public async Task<IMilkResult> GetOrderById(int id)
        {
            var order = await _unitOfWork.GetRepository<Order>().SingleOrDefaultAsync(include: x => x.Include(x => x.OrderDetails));
            return new MilkResult(order);
        }

        public async Task<IMilkResult> CreateOrder(OrderDTO.CreateOrderDTO createOrder)
        {
            Order order = new Order
            {
                AccountId = createOrder.AccountId,
                VoucherCode = createOrder.VoucherCode,
                TotalPrice = createOrder.TotalPrice,
                Status = createOrder.Status
            };
            await _unitOfWork.GetRepository<Order>().InsertAsync(order);
            await _unitOfWork.CommitAsync();

            foreach (var item in createOrder.OrderDetails)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                await _unitOfWork.GetRepository<OrderDetail>().InsertAsync(orderDetail);
                
            }

            MilkResult result = new MilkResult();

            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Data = GetOrderById(order.OrderId);
                result.Status = 1;
                result.Message = "Order created successfully";
            } else
            {
                result.Status = -1;
                result.Message = "Order creation failed";
            }
            return result;
        }

        #endregion
    }
}
