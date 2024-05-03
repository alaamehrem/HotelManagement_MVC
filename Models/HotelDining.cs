using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class HotelDining
    {
        public int Id { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [ForeignKey("Dining")]
        public int DiningId { get; set; }
        public Dining Dining { get; set; }
    }
}
