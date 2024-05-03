using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class HotelOffer
    {
        public int Id { get; set; }
        [ForeignKey("HotelRoom")]
        public int HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
