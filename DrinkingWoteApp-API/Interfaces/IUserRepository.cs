using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetById(int id);
        User GetByUsername(string name);
        decimal GetUserBalance(int Consumenid);
        bool UserExist(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
