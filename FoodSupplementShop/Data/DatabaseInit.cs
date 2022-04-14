using FoodSupplementShop.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodSupplementShop.Data
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
            SeedBrands();
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

        private void SeedBrands()
        {
            if (!_db.Brand.Any())
            {
                List<Brand> brands = new List<Brand>{
                new Brand { Name = "7Nutrition", CreatedDate = DateTime.Now},
                new Brand { Name = "AllMax Nutrition", CreatedDate = DateTime.Now},
                new Brand { Name = "BioTech USA", CreatedDate = DateTime.Now},
                new Brand { Name = "BWG", CreatedDate = DateTime.Now},
                new Brand { Name = "Whey", CreatedDate = DateTime.Now},
                new Brand { Name = "Dymatize", CreatedDate = DateTime.Now},
                };
                _db.AddRange(brands);
                _db.SaveChanges();
            }

        }

        private void SeedProducts()
        {
            int brandsCount = _db.Brand.Count();
            if (brandsCount == 0)
            {
                SeedBrands();
            }
            if (_db.Product.Count() == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    Random rand = new Random();
                    Product product = new Product
                    {
                        Name = "Продукт" + i,
                        Description = "Описание" + i,
                        PhotoUrl = "p" + i + ".jpg",
                        BrandId = rand.Next(1, brandsCount),
                        Price = rand.Next(500, 2000),
                        Quantity = rand.Next(0, 20),
                        CreatedDate = DateTime.Now
                    };

                    _db.Add(product);
                    _db.SaveChanges();
                }
            }
        }
        private void SeedOrders()
        {
            if (_db.Order.Count() == 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    Random random = new Random();
                    int usersCount = _userManager.Users.Count();
                    ApplicationUser buyer = _userManager.Users.Skip(random.Next(0, usersCount)).First();
                    Order order = new Order { CreatedDate = DateTime.Now, Buyer = buyer };
                    _db.Add(order);
                    _db.SaveChanges();
                    int q = random.Next(1, 3);
                    for (int j = 0; j < q; j++)
                    {
                        Product product = _db.Product.Skip(random.Next(0, 5)).First();
                        OrderProduct orderProduct = new OrderProduct { OrderId = order.Id, ProductId = product.Id, Quantity = random.Next(1, 3) };
                        _db.Add(orderProduct);
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
