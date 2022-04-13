using RealEstateShop.Models;
using Microsoft.AspNetCore.Identity;

namespace RealEstateShop.Data
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
            SeedProperties();
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

        private void SeedProperties()
        {
            if (_db.Properties.Count() == 0)
            {
                List<Property> properties = new List<Property>{
                new Property {
                    Name = "Апартамент със стаи",
                    Description = "Една сутрин, когато се събудил от тревожни сънища, той се оказал преобразен в леглото си в ужасен паразит. Лежеше по гръб като броня и ако вдигнеше малко глава, можеше да види кафявия си корем, леко купол и разделен с арки на твърди части.",
                    Location = "Пловдив",
                    PhotoUrl = "p1.jpg",
                    Price = 76445
                },
                new Property {
                    Name = "Апартамент със стаи",
                    Description = "Една сутрин, когато се събудил от тревожни сънища, той се оказал преобразен в леглото си в ужасен паразит. Лежеше по гръб като броня и ако вдигнеше малко глава, можеше да види кафявия си корем, леко купол и разделен с арки на твърди части.",
                    Location = "София",
                    PhotoUrl = "p2.jpg",
                    Price = 54243
                },
                new Property {
                    Name = "Апартамент със стаи",
                    Description = "Една сутрин, когато се събудил от тревожни сънища, той се оказал преобразен в леглото си в ужасен паразит. Лежеше по гръб като броня и ако вдигнеше малко глава, можеше да види кафявия си корем, леко купол и разделен с арки на твърди части.",
                    Location = "Варна",
                    PhotoUrl = "p3.jpg",
                    Price = 95535
                },
                new Property {
                    Name = "Апартамент със стаи",
                    Description = "Една сутрин, когато се събудил от тревожни сънища, той се оказал преобразен в леглото си в ужасен паразит. Лежеше по гръб като броня и ако вдигнеше малко глава, можеше да види кафявия си корем, леко купол и разделен с арки на твърди части.",
                    Location = "Велико търново",
                    PhotoUrl = "p4.jpg",
                    Price = 80000
                },
                new Property {
                    Name = "Апартамент със стаи",
                    Description = "Една сутрин, когато се събудил от тревожни сънища, той се оказал преобразен в леглото си в ужасен паразит. Лежеше по гръб като броня и ако вдигнеше малко глава, можеше да види кафявия си корем, леко купол и разделен с арки на твърди части.",
                    Location = "Враца",
                    PhotoUrl = "p5.jpg",
                    Price = 25000
                },
                };
                _db.AddRange(properties);
                _db.SaveChanges();
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
                    int propertiesCount = _db.Properties.Count();
                    ApplicationUser buyer = _userManager.Users.Skip(random.Next(0, usersCount)).First();
                    Property orderProperty = _db.Properties.Skip(random.Next(0, propertiesCount)).First();
                    Order order = new Order { CreatedDate = DateTime.Now, Buyer = buyer, Property = orderProperty };
                    _db.Add(order);
                    _db.SaveChanges();
                }
            }
        }
    }
}
