namespace HotelManagement_MVC.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public BookingRoom BookingRoom { get; set; }
        public BookingDining BookingDining { get; set; }
        public BookingExperience BookingExperience { get; set; }
    }
}
