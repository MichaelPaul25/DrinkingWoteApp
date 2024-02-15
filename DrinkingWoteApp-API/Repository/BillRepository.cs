using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DrinkingWoteApp_API.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly AppDbContext _context;

        public BillRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool CreateBill(Bill bill, int consumentId, int OrderId)
        {
            var consument = _context.Consuments.Where(c => c.Id== consumentId).FirstOrDefault();
            //bill.Order_Id = OrderId;

            _context.Add(bill);
            return Save();
        }

        public ICollection<Bill> GetAllBill()
        {
            return _context.Bills.ToList();
        }

        public ICollection<Bill> GetBillByConsumenId(int consumentId)
        {
            return _context.Bills.Where(b => b.Consument.Id == consumentId).ToList();
        }

        public Bill GetBillDetails(int id)
        {
            return _context.Bills.Find(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Bill> UnpaidBIll()
        {
            return _context.Bills.Where(b => b.PaymentStatusBill == "UNPAID").ToList();
        }
    }
}
