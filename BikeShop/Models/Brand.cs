using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        //[ForeignKey("Products")]
        //public int ProductId { get; set; }
        public ICollection<Product> Product { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
