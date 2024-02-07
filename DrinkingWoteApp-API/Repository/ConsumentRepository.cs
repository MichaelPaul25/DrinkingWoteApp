using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;

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
            return _context.Consuments.Any(c => c.ConsumentId == id);
        }

        public ICollection<Consument> GetAllConsuments()
        {
            return _context.Consuments.ToList();
        }

        public Consument GetDetailConsument(int id)
        {
            return _context.Consuments.Find(id);
        }
        public decimal GetConsumentBalance(int Consumentid)
        {
            var userBalance =  _context.Consuments.Find(Consumentid);

            if(userBalance == null)
                return 0;

            return Convert.ToDecimal(userBalance.Balance);
            
        }
    }
}
