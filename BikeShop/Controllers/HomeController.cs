using BikeShop.Data;
using BikeShop.Models;
using BikeShop.Views.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IdentityUser user = new IdentityUser();
            IndexModel mod = new BikeShop.Views.Home.IndexModel("EAT DICK FUCKING C#");
            //mod.IndexName = ;
            return View(mod);
        }

        public IActionResult TopOffers(int id)
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}