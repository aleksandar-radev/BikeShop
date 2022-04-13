using System.ComponentModel;

namespace ShoeShop.Models
{
    public class Order
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Купувач")]
        public ApplicationUser? Buyer { get; set; }
        [DisplayName("Обувки")]
        public ICollection<OrderShoe>? Shoes { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Дата на приключване")]
        public DateTime EndDate { get; set; }
        [DisplayName("Статус")]
        public string? Status { get; set; }
        public static List<string> Statuses = new List<string> { "active", "pending", "rejected", "returned", "overdue" };

    }
}
