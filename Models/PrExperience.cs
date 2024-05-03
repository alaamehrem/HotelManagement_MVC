using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class PrExperience
    {
        public int Id { get; set; }
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }

        [ForeignKey("PrivateRetreat")]
        public int PrivateRetreatId { get; set; }
        public PrivateRetreat PrivateRetreat { get; set; }

    }
}
