using HotelManagement_MVC.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class BookingDining
    {
        public int Id { get; set; }
        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public DateTime Date { get; set; }
        public  int NumAdults { get; set; }
        public int Price { get; set; }
        public string? SpecialRequest { get; set; }
    }
}
