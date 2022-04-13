using System.ComponentModel;

namespace BikeShop.Models
{
    public class OrderProduct
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        [DisplayName("Поръчка")]
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        [DisplayName("продукт")]
        public Product? Product { get; set; }

        [DisplayName("количество")]
        public int Quantity { get; set; }
    }
}
