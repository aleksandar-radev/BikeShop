using FoodSupplementShop.Models;

namespace FoodSupplementShop.Views.Home
{
    public class PromotionsViewModel
    {
        public List<Product>? products { get; set; }
        public PromotionsViewModel(List<Product> products)
        {
            this.products = products;
        }
        public List<Product> getProducts()
        {
            if (products == null)
            {
                return new List<Product>();
            }
            return products;
        }
    }
}
