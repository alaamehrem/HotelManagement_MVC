using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class PrReview
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public DateTime DatePosted { get; set; }
        [ForeignKey("Guest")]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        [ForeignKey("PrivateRetreat")]
        public int PrivateRetreatId { get; set; }
        public PrivateRetreat PrivateRetreat { get; set; }

    }
}
