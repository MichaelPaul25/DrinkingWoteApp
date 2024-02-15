using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface IBillRepository
    {
        ICollection<Bill> GetAllBill();
        Bill GetBillDetails(int id);
        ICollection<Bill> GetBillByConsumenId(int id);
        ICollection<Bill> UnpaidBIll();
        bool CreateBill(Bill bill, int consumentId, int OrderId);
        bool Save();
    }
}
