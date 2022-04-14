using FoodSupplementShop.Models;

namespace FoodSupplementShop.Views.Home
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

        public List<Brand> getUniqueBrands()
        {
            if (products == null)
            {
                return new List<Brand>();
            }
            List<Brand> brands = new List<Brand>();
            this.products.ForEach((product) =>
            {
                if (!brands.Contains(product.Brand))
                {
                    brands.Add(product.Brand);
                };
            });
            return brands;
        }
    }
}
