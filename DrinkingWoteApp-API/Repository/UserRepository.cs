using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {

            return _context.Users.Find(id);
        }

        public User GetByUsername(string name)
        {
            return _context.Users.Where(u => u.User_Name == name).FirstOrDefault();
        }

        public decimal GetUserBalance(int Consumenid)
        {
            var balance = _context.Consuments.Where(c => c.ConsumentId == Consumenid).FirstOrDefault();

            if (balance == null)
                return 0;

            return  Convert.ToDecimal(balance.Balance);
        }
        public bool UserExist(int userId)
        {
            return _context.Users.Any(u => u.User_Id == userId);
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.User_Id).ToList();
        }

    }
}
