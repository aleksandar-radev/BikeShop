using System.ComponentModel;

namespace JewelleryShop.Models
{
    public class Product
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string? Name { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("наличност")]
        public int? Stock { get; set; }
        [DisplayName("описание")]
        public string? Description { get; set; }
        [DisplayName("цена")]
        public int Price { get; set; }
        [DisplayName("поръчки")]
        public ICollection<OrderProduct>? Orders { get; set; }
        [DisplayName("адрес на снимка")]
        public string? PhotoUrl { get; set; }
    }
}
