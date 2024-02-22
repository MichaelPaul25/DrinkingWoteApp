using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientSide_DrinkingWoteApp.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatusBill { get; set; }
        public float? TotalPaid { get; set; }
        [ForeignKey("OrderId")]
        public int? Order_Id { get; set; }
        //public Order? Order { get; set; }
        public int? Qty { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Consument? Consument { get; set; }
    }
}
