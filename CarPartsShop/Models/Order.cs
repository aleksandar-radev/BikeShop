using System.ComponentModel;

namespace CarPartsShop.Models
{
    public class Order
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("купувач")]
        public ApplicationUser? Buyer { get; set; }
        [DisplayName("части")]
        public ICollection<OrderPart>? Parts { get; set; }
        [DisplayName("дата на създаване")]
        public DateTime CreatedDate { get; set; }
    }
}
