using DrinkingWoteApp_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Dto
{
    public class BillDto
    {
        public int BillId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatusBill { get; set; }
        public float? TotalPaid { get; set; }
        public int? Order_Id { get; set; }
        public int? Qty { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? ConsumentId { get; set; }
    }
}
