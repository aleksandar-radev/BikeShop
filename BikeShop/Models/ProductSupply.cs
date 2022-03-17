using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class ProductSupply
    {
        [ForeignKey("Product")]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
