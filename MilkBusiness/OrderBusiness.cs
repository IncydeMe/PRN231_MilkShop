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
            var order = await _unitOfWork.GetRepository<Order>().SingleOrDefaultAsync(predicate: o => o.OrderId == id);
            return new MilkResult(order);
        }

        public async Task<IMilkResult> CreateOrder(OrderDTO createOrder)
        {
            Order order = new Order
            {
                OrderId = createOrder.OrderId,
                AccountId = createOrder.AccountId,
                VoucherCode = createOrder.VoucherCode,
                TotalPrice = createOrder.TotalPrice,
                Status = createOrder.Status
            };
            await _unitOfWork.GetRepository<Order>().InsertAsync(order);

            MilkResult result = new MilkResult();

            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Data = await GetOrderById(order.OrderId);
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
