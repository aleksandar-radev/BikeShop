using FoodSupplementShop.Data;
using FoodSupplementShop.Models;
using FoodSupplementShop.Views.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace FoodSupplementShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<Product> products = _db.Product.Include(product => product.Brand).ToList();
            ProductsViewModel m = new ProductsViewModel(products);

            return View(m);
        }

        public IActionResult Promotions()
        {
            List<Product> products = _db.Product.Include(product => product.Brand).ToList();
            List<Product> filteredProducts = products.Where(product => product.Brand.Id < 2).ToList();

            PromotionsViewModel m = new PromotionsViewModel(filteredProducts);

            return View(m);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}