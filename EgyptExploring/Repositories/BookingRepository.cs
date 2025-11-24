using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptExploring.Repositories
{
    public class BookingRepository : IBookinRepository
    {
        private readonly AppDbContext Context;
        public BookingRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public void Create(Booking booking)
        {
            Context.Bookings.Add(booking);
        }

        public void Delete(int UserId, int TripId)
        {
            var DbBooking = Context.Bookings.FirstOrDefault(b => b.UserId == UserId && b.TripId == TripId);
            Context.Bookings.Remove(DbBooking);
        }

        public List<Booking> GetAllById(int UserId)
        {
            return Context.Bookings.Include(b=>b.Trip).Where(b=>b.UserId == UserId).ToList();
        }

        public Booking GetOne(int UserId, int TripId)
        {
            return Context.Bookings.FirstOrDefault(b => b.UserId == UserId && b.TripId == TripId);
        }

        public List<Booking> Read()
        {
            return Context.Bookings.ToList();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            Context.Bookings.Update(booking);
        }



    }
}
