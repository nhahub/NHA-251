using System.ComponentModel.DataAnnotations;

namespace EgyptExploring.ViewModel
{
    public class BookingViewModel
    {
        public int UserId { get; set; }
        public int TripId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPersons { get; set; }

        public decimal PricePerOne { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Title { get; set; }

    }
}
