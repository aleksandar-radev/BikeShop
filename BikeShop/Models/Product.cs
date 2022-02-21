using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Brand")]
        public Brand Brand { get; set; }
        public Brand BrandId { get; set; }
        public int  Size { get; set; }
        public int Price { get; set; }
        public string PhotoUrl { get; set; }
        //[ForeignKey("ProductSupply")]
        //public ProductSupply ProductSupply { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
