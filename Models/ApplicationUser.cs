﻿using Microsoft.AspNetCore.Identity;

namespace HotelManagement_MVC.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}