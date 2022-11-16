using FStoreAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStoreAppLibrary.Data_Layer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public bool DeleteOrder(int orderId) => OrderDBContext.Instance.Delete(orderId);

        public Order GetOrderById(int orderId) => OrderDBContext.Instance.GetOrderById(orderId);

        public List<Order> GetOrders() => OrderDBContext.Instance.GetOrders();

        public List<Order> GetOrdersByMemberId(int memberId) => OrderDBContext.Instance.GetOrdersByMenberId(memberId);

        public List<Order> GetOrdersInDateRange(DateTime startDate, DateTime endDate) => OrderDBContext.Instance.GetOrdersInDateRange(startDate, endDate);
       
        public bool InsertOrder(Order order) => OrderDBContext.Instance.Insert(order);

        public bool UpdateOrder(Order order) => OrderDBContext.Instance.Update(order);
    }
}
