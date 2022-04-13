using System.ComponentModel;

namespace CarPartsShop.Models
{
    public class Part
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string? Name { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Количество")]
        public int? Stock { get; set; }
        [DisplayName("описание")]
        public string? Description { get; set; }
        [DisplayName("цена")]
        public int Price { get; set; }
        [DisplayName("поръчки")]
        public ICollection<OrderPart>? Orders { get; set; }
        [DisplayName("Адрес на снимка")]
        public string? PhotoUrl { get; set; }
    }
}
