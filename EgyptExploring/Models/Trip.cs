using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptExploring.Models
{
    public class Trip
    {
        public int TripId {  get; set; }
        public string TripName { get; set; }
        public string TripDescription { get; set; }
        public decimal TripPrice { get; set; }

        [ForeignKey(nameof(CityId))]    
        public int CityId { get; set; }
        public City City { get; set; }
        public List<AppUser> Users { get; set; }
    
    }
}
