using JewelleryShop.Models;
using Microsoft.AspNetCore.Identity;

namespace JewelleryShop.Data
{
    public class DatabaseInit
    {
        public UserManager<ApplicationUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        public ApplicationDbContext _db;
        public DatabaseInit(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = applicationDbContext;
        }

        public void SeedDb()
        {
            SeedAdmin();
            SeedUsers();
            SeedProducts();
            SeedOrders();
        }

        private void SeedAdmin()
        {
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",

                }, "Admin123!").GetAwaiter().GetResult();
                ApplicationUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@example.com");
                _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
        }
        private void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("User").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }
            if (_userManager.Users.Count() == 1)
            {
                for (int i = 1; i < 10; i++)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = $"user{i}@example.com",
                        Email = $"user{i}@example.com",
                    };
                    _userManager.CreateAsync(user, "Admin123!").GetAwaiter().GetResult();
                    _userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();
                }
            }
        }

        private void SeedProducts()
        {
            if (_db.Products.Count() == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    Random rand = new Random();
                    int size = rand.Next(0, 4);
                    Product product = new Product
                    {
                        Name = "Бижу" + i,
                        Description = "Описание" + i,
                        PhotoUrl = "p" + i + ".jpg",
                        Stock = rand.Next(1, 20),
                        Price = rand.Next(500, 2000),
                        CreatedDate = DateTime.Now
                    };

                    _db.Add(product);
                    _db.SaveChanges();
                }
            }
        }
        private void SeedOrders()
        {
            if (_db.Orders.Count() == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    Random random = new Random();
                    int usersCount = _userManager.Users.Count();
                    int productsCount = _db.Products.Count();
                    ApplicationUser buyer = _userManager.Users.Skip(random.Next(0, usersCount)).First();
                    Order order = new Order { CreatedDate = DateTime.Now, Buyer = buyer };
                    _db.Add(order);
                    _db.SaveChanges();
                    int q = random.Next(1, 3);
                    for (int j = 0; j < q; j++)
                    {
                        Product product = _db.Products.Skip(random.Next(0, productsCount)).First();
                        OrderProduct orderProduct = new OrderProduct { OrderId = order.Id, ProductId = product.Id, Quantity = random.Next(1, 3) };
                        _db.Add(orderProduct);
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
