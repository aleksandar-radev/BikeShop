using System.ComponentModel;

namespace ShoeShop.Models
{
    public class Shoe
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string? Name { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Размер")]
        public int Size { get; set; }
        [DisplayName("Количество")]
        public int? Stock { get; set; }
        [DisplayName("Описание")]
        public string? Description { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        [DisplayName("Поръчки")]
        public ICollection<OrderShoe>? Orders { get; set; }
        [DisplayName("Адрес на снимка")]
        public string? PhotoUrl { get; set; }
    }
}
