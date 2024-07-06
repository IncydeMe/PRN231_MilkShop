using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness;

public class OrderDetailBusiness
{
    //private readonly UnitOfWork _unitOfWork;

    //public OrderDetailBusiness()
    //{
    //    _unitOfWork ??= new UnitOfWork();
    //}
    //#region OrderDetail
    //public async Task<IMilkResult> GetAllOrderDetail()
    //{
    //    var orderDetailList = await _unitOfWork.GetRepository<OrderDetail>().GetListAsync();
    //    return new MilkResult(orderDetailList);
    //}

    //public async Task<IMilkResult> GetOrderDetailById(int orderDetailId)
    //{
    //    var orderDetail = await _unitOfWork.GetRepository<OrderDetail>().SingleOrDefaultAsync(predicate: o => o.OrderDetailId == orderDetailId);
    //    return new MilkResult(orderDetail);
    //}

    //public async Task<IMilkResult> CreateOrderDetail(OrderDetailDTO createOrderDetail)
    //{
    //    OrderDetail orderDetail = new OrderDetail
    //    {
    //        OrderDetailId = createOrderDetail.OrderDetailId,
    //        OrderId = createOrderDetail.OrderId,
    //        ProductId = createOrderDetail.ProductId,
    //        Quantity = createOrderDetail.Quantity,
    //    };
    //    await _unitOfWork.GetRepository<OrderDetail>().InsertAsync(orderDetail);

    //    MilkResult result = new MilkResult();

    //    bool status = await _unitOfWork.CommitAsync() > 0;
    //    if (status)
    //    {
    //        result.Status = 1;
    //        result.Message = "OrderDetail created successfully";
    //    } else
    //    {
    //        result.Status = -1;
    //        result.Message = "OrderDetail creation failed";
    //    }
    //    return result;
    //}
    //#endregion
}
