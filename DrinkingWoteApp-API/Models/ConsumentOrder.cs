namespace DrinkingWoteApp_API.Models
{
    public class ConsumentOrder
    {
        public int? JoinConsumentId { get; set; }
        public int? JoinOrderId { get; set; }
        public Consument? Consument { get; set; }
        public Order? Order { get; set; }
    }
}
