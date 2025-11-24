using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgyptExploring.Models
{
    public class Destination
    {
        
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(CityId))]
        public int CityId { get; set; }
        public City City { get; set; }


    }
}
