using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptExploring.Repositories
{
    public class CityRepositry : ICityRepositry
    {
        private readonly AppDbContext Context;
        public CityRepositry(AppDbContext _Context)
        {
            Context=_Context;
        }
        public void Create(City city)
        {
            Context.Citys.Add(city);
        }

        public void Delete(int id )
        {
            City DbCity = GetOne(id);
            Context.Citys.Remove(DbCity);
        }

        public List<City> Read()
        {
            return Context.Citys.ToList();
        }

        public void Update(City city)
        {
            Context.Citys.Update(city);
        }

        public City GetOne(int id)
        {
            return Context.Citys.Include(c=>c.Destinations).FirstOrDefault(c=>c.CityId==id);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
