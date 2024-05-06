using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class HotelReview
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public DateTime DatePosted { get; set; }
        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        //[ForeignKey("HotelRoom")]
        //public int HotelRoomId { get; set; }
        //public HotelRoom HotelRoom { get; set; }
    }
}
