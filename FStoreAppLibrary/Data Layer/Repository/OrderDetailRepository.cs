using FStoreAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStoreAppLibrary.Data_Layer.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public bool DeleteOrderDetail(int orderId, int productId) => OrderDetailDBContext.Instance.Delete(orderId, productId);

        public OrderDetail GetOrderDetailById(int orderId, int productId) => OrderDetailDBContext.Instance.GetOrderDetailById(orderId, productId);
        public List<OrderDetail> GetOrderDetails() => OrderDetailDBContext.Instance.GetOrderDetails();

        public bool InsertOrderDetail(OrderDetail orderDetail) => OrderDetailDBContext.Instance.Insert(orderDetail);

        public bool UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDBContext.Instance.Update(orderDetail);

        public List<OrderDetail> GetOrderItemsByOrderId(int orderId) => OrderDetailDBContext.Instance.GetOrderItemsByOrderId(orderId);
    }
}
