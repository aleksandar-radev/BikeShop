using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Brand? Brand { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public string? PhotoUrl { get; set; }
        public ProductSupply? ProductSupply { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
