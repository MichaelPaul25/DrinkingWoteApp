using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly AppDbContext _context;

        public BillRepository(AppDbContext context)
        {
            _context = context;
        }
        public ICollection<Bill> GetAllBill()
        {
            return _context.Bills.ToList();
        }

        public ICollection<Bill> GetBillByConsumenId(int consumentId)
        {
            return _context.Bills.Where(b => b.Consument.ConsumentId == consumentId).ToList();
        }

        public Bill GetBillDetails(int id)
        {
            return _context.Bills.Find(id);
        }

        public ICollection<Bill> UnpaidBIll()
        {
            return _context.Bills.Where(b => b.PaymentStatus == "UNPAID").ToList();
        }
    }
}
