using MilkData.DTOs;
using MilkData.DTOs.Order;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MilkData.DTOs.Order.OrderDetailDTO;

namespace MilkBusiness
{
    public class OrderDetailBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderDetailBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        #region OrderDetail
        public async Task<IMilkResult> GetAllOrderDetail()
        {
            var orderDetailList = await _unitOfWork.GetRepository<OrderDetail>().GetListAsync(
                selector: x => new
                {
                    x.OrderDetailId,
                    x.Quantity,
                    x.ProductId,
                    x.OrderId
                });
            return new MilkResult(orderDetailList);
        }

        public async Task<IMilkResult> GetOrderDetailById(int orderDetailId)
        {
            var orderDetail = await _unitOfWork.GetRepository<OrderDetail>().SingleOrDefaultAsync(
                predicate: o => o.OrderDetailId == orderDetailId);
            return new MilkResult(orderDetail);
        }

        public async Task<IMilkResult> CreateOrderDetail(OrderDetailsInput createOrderDetail)
        {
            foreach (var orderDetails in createOrderDetail.OrderDetails)
            {
                OrderDetail newOrderDetail = new OrderDetail
                {
                    OrderDetailId = _unitOfWork.GetRepository<OrderDetail>().GetListAsync().Result.Max(o => o.OrderDetailId) + 1,
                    OrderId = createOrderDetail.OrderId,
                    ProductId = orderDetails.ProductId,
                    Quantity = orderDetails.Quantity,
                };
                await _unitOfWork.GetRepository<OrderDetail>().InsertAsync(newOrderDetail);
            }

            MilkResult result = new MilkResult();

            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Status = 1;
                result.Message = "OrderDetail created successfully";
            } else
            {
                result.Status = -1;
                result.Message = "OrderDetail creation failed";
            }
            return result;
        }
        #endregion
    }
}
