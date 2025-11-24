using EgyptExploring.Models;
using System.Runtime.InteropServices;

namespace EgyptExploring.RepositryInterfaces
{
    public interface ICityRepositry
    {
        public void Create(City city);
        public List<City> Read();
        public void Update(City city);
        public void Delete(int id);
        public City GetOne(int id);
        public void Save();

    }
}
