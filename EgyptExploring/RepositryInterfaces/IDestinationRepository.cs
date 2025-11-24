using EgyptExploring.Models;

namespace EgyptExploring.RepositryInterfaces
{
    public interface IDestinationRepository
    {
        public void Create(Destination destination);
        public List<Destination> Read();
        public void Update(Destination destination);
        public void Delete(int id);
        public Destination GetOne(int id);
        public void Save();
    }
}
