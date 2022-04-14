using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSupplementShop.Models
{
    public class Product
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string? Name { get; set; }
        [DisplayName("Описание")]
        public string? Description { get; set; }
        [DisplayName("Идентификатор на марка")]
        public int BrandId { get; set; }
        [DisplayName("Марка")]
        public Brand? Brand { get; set; }
        [DisplayName("цена")]
        public int Price { get; set; }
        [DisplayName("количество")]
        public int Quantity { get; set; }
        [DisplayName("адрес на снимка")]
        public string? PhotoUrl { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Поръчки")]
        public ICollection<OrderProduct>? Orders { get; set; } 
    }
}
