using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IConsumentRepository
    {
        ICollection<Consument> GetAllConsuments();
        Consument GetDetailConsument(int id);
        bool CheckUserHaveCustomerId(int userId);
        decimal GetConsumentBalance(int Consumentid);
        bool ConsumentExists(int id);
        bool CreateConsument(int UserId, Consument consument);
        bool UpdateConsument(int Id, Consument consument);
        bool DeleteConsument(Consument consument);
        bool Save();
    }
}
