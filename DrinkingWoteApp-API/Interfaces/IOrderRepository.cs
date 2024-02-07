using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IOrderRepository
    {
        public ICollection<Order> GetAllOrders();
        public Order GetOrderDetail(int id);
        public ICollection<Order> GetProcessOrder();
        public decimal CountProcessOrder();
        public bool OrderExist(int id);
    }
}
