using System.ComponentModel;

namespace ShoeShop.Models
{
    public class OrderShoe
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Идентификатор на поръчка")]
        public int OrderId { get; set; }
        [DisplayName("поръчка")]
        public Order? Order { get; set; }
        [DisplayName("идентификатор на обувки")]
        public int ShoeId { get; set; }
        [DisplayName("обувки")]
        public Shoe? Shoe { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }
    }
}
