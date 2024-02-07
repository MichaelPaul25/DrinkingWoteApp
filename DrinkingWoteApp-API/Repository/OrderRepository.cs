using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _content;

        public OrderRepository(AppDbContext content)
        {
            _content = content;
        }

        //Get all
        public ICollection<Order> GetAllOrders()
        {
            return _content.Orders.ToList();
        }

        //Get Order Detail
        public Order GetOrderDetail(int id)
        {
            return _content.Orders.Find(id);
        }

        //Get all Process Order
        public ICollection<Order> GetProcessOrder() 
        {
            var orders = _content.Orders.Where(o => o.StatusOrder == "PROCESS");

            return orders.ToList();
        }

        //Count process Order
        public decimal CountProcessOrder()
        {
            var orders = _content.Orders.Where(o => o.StatusOrder == "PROCESS");

            return orders.Count();
        }

        //Find Exist Order
        public bool OrderExist(int OrderId)
        {
            return _content.Orders.Any(o => o.OrderId == OrderId);
        }

    }
}
