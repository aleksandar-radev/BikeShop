using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Brand
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string? Name { get; set; }
        [DisplayName("Продукт")]
        public ICollection<Product>? Product { get; set; }
        [DisplayName("дата на създаване")]
        public DateTime CreatedDate { get; set; }
    }
}
