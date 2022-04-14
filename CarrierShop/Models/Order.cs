using System.ComponentModel;

namespace CarrierShop.Models
{
    public class Order
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Описание на пратка")]
        public string? ParcelDescription { get; set; }
        [DisplayName("Килограми")]
        public int Kg { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("идентификатор на услуга")]
        public int ServiceId { get; set; }
        [DisplayName("услуга")]
        public Service? Service { get; set; }
        [DisplayName("Купувач")]
        public ApplicationUser? Customer { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }

    }
}
