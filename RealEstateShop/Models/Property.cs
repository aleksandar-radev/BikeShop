using System.ComponentModel;

namespace RealEstateShop.Models
{
    public class Property
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string? Name { get; set; }
        [DisplayName("Локация")]
        public string? Location { get; set; }
        [DisplayName("адрес на снимка")]
        public string? PhotoUrl { get; set; }
        [DisplayName("поръчка")]
        public Order? Order { get; set; }
        [DisplayName("описание")]
        public string? Description { get; set; }
        [DisplayName("цена")]
        public double? Price { get; set; }


    }
}
