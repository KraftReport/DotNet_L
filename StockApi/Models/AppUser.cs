﻿using Microsoft.AspNetCore.Identity;

namespace StockApi.Models
{

    public class AppUser : IdentityUser
    {
        public List<Portfolio> portfolios { get; set; } = new List<Portfolio>();
    }
}