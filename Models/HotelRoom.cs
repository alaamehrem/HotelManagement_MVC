using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class HotelRoom
    {
        public int Id { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [ForeignKey("HotelFloor")]
        public int HotelFloorId { get; set; }
        public HotelFloor HotelFloor { get; set; }
        [ForeignKey("HotelRoomType")]
        public int HotelRoomTypeId { get; set; }
        public HotelRoomType HotelRoomType { get; set; }
        [ForeignKey("BookingRoom")]
        public int BookingRoomId { get; set; }
        public BookingRoom BookingRoom { get; set; }
        public int Price { get; set; }
    }
}
