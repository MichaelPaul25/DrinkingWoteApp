using System.ComponentModel.DataAnnotations;

namespace DrinkingWoteApp_API.Models
{
    public class Perumahan
    {
        [Key]
        public int Perumahan_Id { get; set; }
        public string Perumahan_Name { get; set;}
    }
}
