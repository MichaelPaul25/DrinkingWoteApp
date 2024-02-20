using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetAllOrders();
        ICollection<Order> GetOrdersbyConsument(int consumentId);
        Order GetOrderDetail(int id);
        ICollection<Order> GetProcessOrder();
        decimal CountProcessOrder();
        bool OrderExist(int id);
        bool CreateOrder(Order order, int consumentId, int crewId);
        bool UpdateOrder(Order order, int consumentId, int OrderId);
        bool DeleteOrder(Order order);
        bool Save();
    }
}
