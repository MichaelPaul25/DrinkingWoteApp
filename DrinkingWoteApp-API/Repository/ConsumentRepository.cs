using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkingWoteApp_API.Repository
{
    public class ConsumentRepository : IConsumentRepository
    {
        private readonly AppDbContext _context;

        public ConsumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool ConsumentExists(int id)
        {
            return _context.Consuments.Any(c => c.Id == id);
        }

        public ICollection<Consument> GetAllConsuments()
        {
            return _context.Consuments.ToList();
        }

        public Consument GetDetailConsument(int id)
        {
            //return _context.Consuments.Find(id);
            var consumentDetails = _context.Consuments.Where(c => c.Id == id)
                                    .Include(a => a.Address)
                                    .FirstOrDefault();
            //var address = _context.Address.Where(a => a.AddressId = consumentDetails.Address)

            return consumentDetails;
        }
        public decimal GetConsumentBalance(int Consumentid)
        {
            var userBalance =  _context.Consuments.Find(Consumentid);

            if(userBalance == null)
                return 0;

            return Convert.ToDecimal(userBalance.Balance);
            
        }

        public bool CreateConsument(int UserId, Consument consument)
        {
            var user = _context.Users.Find(UserId);

            consument.User = user;

            _context.Add(consument);
            //Add new Consument ID in User ID field
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CheckUserHaveCustomerId(int userId)
        {
            var consument = _context.Users.Where(c => c.Id == userId.ToString()).Select(a => a.Consument != null).FirstOrDefault();
            if (consument)
                return true;
            else
                return false;
        }

        public bool UpdateConsument(int Id, Consument consument)
        {
            _context.Update(consument);
            return Save();
        }

        public bool DeleteConsument(Consument consument)
        {
            _context.Remove(consument);
            return Save();
        }
    }
}
