namespace BikeShop.Models
{
    public class Order
    {

        public int Id { get; set; }
        public ApplicationUser? Buyer { get; set; }
        public ICollection<OrderProduct>? Products { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
