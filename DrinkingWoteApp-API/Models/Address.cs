using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinkingWoteApp_API.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public Perumahan? Perumahan{ get; set; }
        public string Block { get; set; }
        public string RT_RW { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
    }
}
