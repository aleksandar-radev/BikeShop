using System.ComponentModel;

namespace CarPartsShop.Models
{
    public class OrderPart
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Идентификатор на поръчка")]
        public int OrderId { get; set; }
        [DisplayName("поръчка")]
        public Order? Order { get; set; }
        [DisplayName("Идентификатор на част")]
        public int PartId { get; set; }
        [DisplayName("част")]
        public Part? Part { get; set; }
        [DisplayName("Количество")]

        public int Quantity { get; set; }
    }
}
