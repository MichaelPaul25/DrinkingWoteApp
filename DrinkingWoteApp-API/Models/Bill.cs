using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public float? TotalPaid { get; set; }
        [ForeignKey("OrderId")]
        public int? Order_Id { get; set; }
        public int? Qty { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Consument? Consument { get; set; }

    }
}
