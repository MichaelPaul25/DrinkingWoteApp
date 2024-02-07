using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IConsumentRepository
    {
        ICollection<Consument> GetAllConsuments();
        Consument GetDetailConsument(int id);
        decimal GetConsumentBalance(int Consumentid);
        bool ConsumentExists(int id);
    }
}
