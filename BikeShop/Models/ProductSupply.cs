using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class ProductSupply
    {
        public int Id { get; set; }
        //[ForeignKey("Product")]
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
