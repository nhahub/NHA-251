using System.ComponentModel.DataAnnotations;

namespace EgyptExploring.Models
{
    public class City
    {
      
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string? Image { get; set; }
        public List<Destination> Destinations { get; set; }
        public List<Trip> Trips { get; set; }
        

    }
}
