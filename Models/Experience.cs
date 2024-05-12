namespace HotelManagement_MVC.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }
        public List<BookingExperience>? BookingExperiences { get; set; }
    }
}
