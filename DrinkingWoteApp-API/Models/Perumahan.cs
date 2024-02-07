using System.ComponentModel.DataAnnotations;

namespace DrinkingWoteApp_API.Models
{
    public class Perumahan
    {
        [Key]
        public int PerumahanId { get; set; }
        public string Perumahan_Name { get; set;}
    }
}
