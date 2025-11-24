using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EgyptExploring.Repositories
{
    public class AppUserRepository:IAppUserRepository
    {
        private readonly AppDbContext Context;
        public AppUserRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public void Create(AppUser user)
        {
            Context.Users.Add(user);
        }

        public void Delete(int id)
        {
            AppUser Dbuser = GetOne(id);
            Context.Users.Remove(Dbuser);
        }

        public List<AppUser> Read()
        {
            return Context.Users.ToList();
        }

        public void Update(AppUser user)
        {
            Context.Users.Update(user);
        }

        public AppUser GetOne(int id)
        {
            return Context.Users.FirstOrDefault(U=>U.Id==id);
        }
        public void Save()
        {
            Context.SaveChanges();
        }

        //public List<AppUser> GetAllUsers()
        //{
        //   return Context.Users.Include(u=>u)
        //}
    }
}
