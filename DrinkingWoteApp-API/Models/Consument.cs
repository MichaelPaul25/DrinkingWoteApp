using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Consument
    {
        [Key]
        public int ConsumentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? JoinDate { get; set; }
        public float? Balance { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public Address? Address { get; set; }
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        //public ICollection<ConsumentOrder>? ConsumenOrders { get; set; }
    }
}
