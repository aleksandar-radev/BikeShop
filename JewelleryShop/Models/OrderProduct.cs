using System.ComponentModel;

namespace JewelleryShop.Models
{
    public class OrderProduct
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Ид на поръчка")]
        public int OrderId { get; set; }
        [DisplayName("поръчка")]
        public Order? Order { get; set; }
        [DisplayName("ид на бижу")]
        public int ProductId { get; set; }
        [DisplayName("бижу")]
        public Product? Product { get; set; }
        [DisplayName("количество")]

        public int Quantity { get; set; }
    }
}
