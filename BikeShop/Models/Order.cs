namespace BikeShop.Models
{
    public class Order
    {

        public int Id { get; set; }
        public ApplicationUser? Buyer { get; set; }
        public ICollection<Product>? Products { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
