﻿using Microsoft.AspNetCore.Identity;

namespace BikeShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Egn { get; set; }
    }
}