using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class Dining
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Images { get; set; }
        [ForeignKey("BookingDining")]
        public int BookingDiningId { get; set; }
        public BookingDining BookingDining { get; set; }
    }
}
