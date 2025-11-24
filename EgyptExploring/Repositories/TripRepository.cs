using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;

namespace EgyptExploring.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly AppDbContext Context;
        public TripRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public void Create(Trip trip)
        {
            Context.Trips.Add(trip);
            
        }

        public void Delete(int id)
        {
            Trip trip = GetOne(id);
            Context.Trips.Remove(trip);
        }

        public Trip GetOne(int id)
        {
            return Context.Trips.FirstOrDefault(t => t.TripId == id);
        }

        public List<Trip> Read()
        {
           return Context.Trips.ToList();

        }

        public void Save()
        {
           Context.SaveChanges();
        }

        public void Update(Trip trip)
        {
            Context.Update(trip);
        }
    }
}
