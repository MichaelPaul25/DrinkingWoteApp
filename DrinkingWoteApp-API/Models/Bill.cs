using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Bill
    {
        [Key]
        public int Bill_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        public string? PaymentMethod { get; set; }
        public float TotalPaid { get; set; }
        public int Qty { get; set; }
        public DateTime? PaymentDate { get; set; }
        [ForeignKey("Consument_Id")]
        public Consumen? Consumen { get; set; }

    }
}
