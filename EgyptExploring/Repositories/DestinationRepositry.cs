using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;

namespace EgyptExploring.Repositories
{
    public class DestinationRepositry:IDestinationRepository
    {
        private readonly AppDbContext Context;
        public DestinationRepositry(AppDbContext _Context)
        {
            Context = _Context;
        }

        public void Create(Destination destination)
        {
            Context.Destinations.Add(destination);
        }

        public void Delete(int id)
        {
            Destination destination = GetOne(id);
            Context.Destinations.Remove(destination);
        }

        public List<Destination> Read()
        {
            return Context.Destinations.ToList();
        }

        public void Update(Destination destination)
        {
            Context.Destinations.Update(destination);
        }

        public Destination GetOne(int id)
        {
            return Context.Destinations.FirstOrDefault(d => d.DestinationId == id);
        }
        public void Save()
        {
            Context.SaveChanges();
        }


    }
}
