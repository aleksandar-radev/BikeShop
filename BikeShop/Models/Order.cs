namespace BikeShop.Models
{
    public class Order
    {

        public int Id { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        //public Product Product { get; set; }
        //public int Price
        //{
        //    get { return Product.Price * Quantity; }
        //}
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
