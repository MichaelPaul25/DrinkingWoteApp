using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IBillRepository
    {
        public ICollection<Bill> GetAllBill();
        public Bill GetBillDetails(int id);
        public ICollection<Bill> GetBillByConsumenId(int id);
        public ICollection<Bill> UnpaidBIll();
    }
}
