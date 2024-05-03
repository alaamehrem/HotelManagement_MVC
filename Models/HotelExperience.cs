using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_MVC.Models
{
    public class HotelExperience
    {
        public int Id { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
