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
        bool Save();
    }
}
