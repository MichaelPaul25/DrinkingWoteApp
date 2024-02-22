using ClientSide_DrinkingWoteApp.Models;

namespace ClientSide_DrinkingWoteApp.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Task<Order> GetById(int id);
    }
}
