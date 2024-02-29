using ClientSide_DrinkingWoteApp.Models;

namespace ClientSide_DrinkingWoteApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserDetail(int UserId);
        bool SignUp(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
