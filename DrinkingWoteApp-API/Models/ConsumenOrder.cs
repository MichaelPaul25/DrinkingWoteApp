namespace DrinkingWoteApp_API.Models
{
    public class ConsumenOrder
    {
        public int Consumen_Id { get; set; }
        public int Order_Id { get; set; }
        public Consumen Consumen { get; set; }
        public Order Order { get; set; }
    }
}
