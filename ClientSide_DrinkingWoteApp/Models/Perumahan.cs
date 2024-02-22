using System.ComponentModel.DataAnnotations;

namespace ClientSide_DrinkingWoteApp.Models
{
    public class Perumahan
    {
        [Key]
        public int PerumahanId { get; set; }
        public string Perumahan_Name { get; set; }
    }
}
