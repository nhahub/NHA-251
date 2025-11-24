using EgyptExploring.Models;

namespace EgyptExploring.RepositryInterfaces
{
    public interface ITripRepository
    {
        public void Create(Trip trip);
        public List<Trip> Read();
        public void Update(Trip trip);
        public void Delete(int id);
        public Trip GetOne(int id);
        public void Save();
    }
}
