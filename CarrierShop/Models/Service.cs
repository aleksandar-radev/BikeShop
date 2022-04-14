using System.ComponentModel;

namespace CarrierShop.Models
{
    public class Service
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string Name { get; set; }
        [DisplayName("Цена на Килограм")]
        public int PricePerKg { get; set; }
        [DisplayName("Цена на километър")]
        public int PricePerKm { get; set; }
        [DisplayName("Максимум килограми")]
        public int MaxKg { get; set; }
        [DisplayName("Поръчки")]
        public ICollection<Order>? Orders { get; set; }
        public Service(string name)
        {
            Name = name;
        }
    }
}
