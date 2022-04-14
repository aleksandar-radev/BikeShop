using System.ComponentModel;

namespace FoodSupplementShop.Models
{
    public class Order
    {

        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("купувач")]
        public ApplicationUser? Buyer { get; set; }
        [DisplayName("Продукти")]
        public ICollection<OrderProduct>? Products { get; set; }
        [DisplayName("дата на създаване")]
        public DateTime CreatedDate { get; set; }

    }
}
