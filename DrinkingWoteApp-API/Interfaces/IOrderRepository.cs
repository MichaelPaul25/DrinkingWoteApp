using DrinkingWoteApp_API.Models;
using DrinkingWoteApp_API.Dto;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetAllOrders();
        ICollection<Order> GetOrdersbyConsument(int consumentId);
        Order GetOrderDetail(int id);
        ICollection<Order> GetOrderToday();
        ICollection<Order> GetProcessOrder();
        decimal CountProcessOrder();
        bool OrderExist(int id);
        bool CreateOrder(Order order, int consumentId, int crewId);
        bool UpdateOrder(Order order, int consumentId, int OrderId);
        bool DeleteOrder(Order order);
        bool Save();
        double CountOrderToday();
        QuickCountDto quickcount();
    }
}
