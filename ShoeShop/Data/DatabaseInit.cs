using ShoeShop.Models;
using Microsoft.AspNetCore.Identity;

namespace ShoeShop.Data
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
            SeedShoes();
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

        private void SeedShoes()
        {
            if (_db.Shoes.Count() == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    Random rand = new Random();
                    int size = rand.Next(0, 14);
                    Shoe shoe = new Shoe
                    {
                        Name = "Име" + i,
                        Description = "описание " + i,
                        Stock = rand.Next(0, 500),
                        PhotoUrl = "shoe" + i + ".jpg",
                        Size = 14 + size * 2,
                        Price = rand.Next(500, 2000),
                        CreatedDate = DateTime.Now
                    };

                    _db.Add(shoe);
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
                    Order order = new Order { CreatedDate = DateTime.Now, Buyer = buyer, EndDate = DateTime.Now.AddMonths(1), Status = Order.Statuses[random.Next(0, 4)] };
                    _db.Add(order);
                    _db.SaveChanges();
                    int q = random.Next(1, 3);
                    for (int j = 0; j < q; j++)
                    {
                        Shoe shoe = _db.Shoes.Skip(random.Next(0, 5)).First();
                        OrderShoe orderShoe = new OrderShoe { OrderId = order.Id, ShoeId = shoe.Id, Quantity = random.Next(1, 3) };
                        _db.Add(orderShoe);
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
