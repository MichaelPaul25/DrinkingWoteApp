using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Consumen
    {
        [Key]
        public int Consumen_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public float? Balance { get; set; }
        [ForeignKey("Order_Id")]
        public virtual ICollection<Order>? Orders { get; set; }
        [ForeignKey("Address_Id")]
        public Address Address { get; set; }
        [ForeignKey("Review_Id")]
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<ConsumenOrder> ConsumenOrders { get; set; }
    }
}
