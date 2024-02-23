using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public Consument? Consument { get; set; }
        public string? StatusOrder { get; set; }
        public int? Qty { get; set; }
        public DateTime TimeOrder { get; set; }
        public DateTime? OrderDone { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public Bill? Bill { get; set; }
        public Review? Review { get; set; }
        public CrewMember? Crew { get; set; }
    }
}
