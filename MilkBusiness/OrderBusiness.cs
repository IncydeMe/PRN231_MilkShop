using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
