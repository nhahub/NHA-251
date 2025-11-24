using EgyptExploring.Models;

namespace EgyptExploring.RepositryInterfaces
{
    public interface IBookinRepository
    {

        public void Create(Booking booking);
        public List<Booking> Read();
        public void Update(Booking booking);
        public void Delete(int UserId, int TripId);
        public Booking GetOne(int UserId, int TripId);
        public List<Booking> GetAllById(int UserId);
        public void Save();
    }
}
