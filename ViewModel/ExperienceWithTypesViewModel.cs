﻿using HotelManagement_MVC.Models;

namespace HotelManagement_MVC.ViewModel
{
    public class ExperienceWithTypesViewModel
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public List<ExperienceType> Type { get; set; } 
        public string Description { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }
        //public List<BookingExperience>? BookingExperiences { get; set; }
        public int TypeId { get; set; }
        //public string? TypeName { get; set; }
        //public List<Experience>? Experiences { get; set; }
    }
}
