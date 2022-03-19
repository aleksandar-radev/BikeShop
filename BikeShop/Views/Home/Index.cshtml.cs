using BikeShop.Models;
using Microsoft.AspNetCore.Identity;
namespace BikeShop.Views.Home
{
    public class Index
    {
        public UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationUser User { get; set; }
        public Index(UserManager<ApplicationUser> _userManager)
        {
            UserManager = _userManager;
            Task<ApplicationUser> task = UserManager.FindByNameAsync("admin@example.com");
            User = task.Result;
            Console.WriteLine('a');
        }
    }
}
