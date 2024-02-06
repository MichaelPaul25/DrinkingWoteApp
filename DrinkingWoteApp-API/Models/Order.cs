using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        [ForeignKey("Consumen_Id")]
        public Consumen Consumen { get; set; }
        public string StatusOrder { get; set; }
        public int Qty { get; set; }
        public DateTime TimeOrder { get; set; }
        public DateTime? OrderDone { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        [ForeignKey("Bill_Id")]
        public Bill? Bill { get; set; }
        [ForeignKey("Review_Id")]
        public Review? Review { get; set; }
        [ForeignKey("Crew_Id")]
        public CrewMember? Crew { get; set; }
    }
}
