using EgyptExploring.Models;

namespace EgyptExploring.RepositryInterfaces
{
    public interface IAppUserRepository
    {
        public void Create( AppUser User);
        public List<AppUser> Read();
        public void Update(AppUser User);
        public void Delete(int id);
        public AppUser GetOne(int id);
        //public List<AppUser> GetAllUsers();
        public void Save();
    }
}
