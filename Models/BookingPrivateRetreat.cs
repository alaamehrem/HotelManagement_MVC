using HotelManagement_MVC.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class BookingPrivateRetreat
    {
        public int Id { get; set; }
        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        [ForeignKey("PrivateRetreat")]
        public int PrivateRetreatId { get; set; }
        public PrivateRetreat PrivateRetreat { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; } = 0;
        public int Price { get; set; }
        public string? SpecialRequest { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
