using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BikeShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        [MaxLength(10)]
        public string? Egn { get; set; }

        public void SetFirstName()
        {
            FirstName = FirstName ?? string.Empty;
        }
    }
}