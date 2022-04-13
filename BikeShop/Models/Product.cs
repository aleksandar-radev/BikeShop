using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeShop.Models
{
    public class Product
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        public int BrandId { get; set; }
        [DisplayName("Марка")]
        public Brand? Brand { get; set; }
        [Range(0, int.MaxValue)]
        [DisplayName("размер")]
        public int Size { get; set; }
        [DisplayName("цена")]
        public int Price { get; set; }
        [DisplayName("адрес на снимка")]
        public string? PhotoUrl { get; set; }
        [DisplayName("количество")]
        public ProductSupply? ProductSupply { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Поръчки")]
        public ICollection<OrderProduct>? Orders { get; set; } 
    }
}
