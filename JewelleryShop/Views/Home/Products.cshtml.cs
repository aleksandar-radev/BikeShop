using JewelleryShop.Models;

namespace JewelleryShop.Views.Home
{
    public class ProductsViewModel
    {
        public List<Product>? products { get; set; }

        public ProductsViewModel(List<Product> products)
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
