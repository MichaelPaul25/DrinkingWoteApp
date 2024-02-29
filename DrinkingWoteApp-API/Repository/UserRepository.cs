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
            var balance = _context.Consuments.Where(c => c.Id == Consumenid).FirstOrDefault();

            if (balance == null)
                return 0;

            return  Convert.ToDecimal(balance.Balance);
        }
        public bool UserExist(int userId)
        {
            return _context.Users.Any(u => u.Id == userId.ToString());
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }
    }
}
