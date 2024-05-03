using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class PrOffer
    {
        public int Id { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        [ForeignKey("PrivateRetreat")]
        public int PrivateRetreatId { get; set; }
        public PrivateRetreat PrivateRetreat { get; set; }
    }
}
