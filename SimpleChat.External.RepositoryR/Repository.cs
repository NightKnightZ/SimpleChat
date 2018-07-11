using SimpleChat.Business.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SimpleChat.External.RepositoryR
{
    class Repository<T> : IRepository<T>
        where T : class
    {
        DbSet<T> dbset;
        Context context;

        public Repository(string connectionString)
        {
            context = new Context(connectionString);
            dbset = context.Set<T>();
        }

        public void Add(T item)
        {
            dbset.Add(item);
        }

        public T GetItem(int id)
        {
            return dbset.Find(id);
        }

        public void Update(T item)
        {
            dbset.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }

        public void DeleteItem(int id)
        {
            dbset.Remove(dbset.Find(id));
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
