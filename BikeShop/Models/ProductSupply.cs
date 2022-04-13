using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class ProductSupply
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("количество")]
        public int Quantity { get; set; }
        [DisplayName("дата на създаване")]
        public DateTime CreatedDate { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Продукт")]
        public Product? Product { get; set; }
    }
}
