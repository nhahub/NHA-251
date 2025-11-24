using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EgyptExploring.Models
{
    public class Booking
    {
        
        public int UserId { get; set; }
        public int TripId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPersons { get; set; }
        public decimal TotalPrice { get; set; }
        public AppUser User { get; set; }
        public Trip Trip { get; set; }


    }
}
