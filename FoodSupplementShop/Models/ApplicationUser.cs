using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodSupplementShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Име")]
        public string? FirstName { get; set; }
        [DisplayName("Презиме")]
        public string? MiddleName { get; set; }
        [DisplayName("Фамилия")]
        public string? LastName { get; set; }
        [DisplayName("ЕГН")]
        [MaxLength(10)]
        public string? Egn { get; set; }

        public void SetFirstName()
        {
            FirstName = FirstName ?? string.Empty;
        }
    }
}