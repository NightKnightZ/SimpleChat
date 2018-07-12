using SimpleChat.Messaging.Interfaces;
using SimpleChat.Messaging.Database.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace SimpleChat.Messaging.Database.Sqlite
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        DbSet<T> dbset;
        MessagingContext context;
        IDatabaseSettings dbSettings;

        public Repository(IDatabaseSettings dbSettings)
        {
            this.dbSettings = dbSettings;
            context = new MessagingContext(dbSettings);
            dbset = context.Set<T>(); 
        }

        public void CreateDatabase()
        {
            if (!File.Exists(dbSettings.ConnectionString))
            { context.Database.EnsureCreated(); }
        }

        public void ContextDispose()
        {
            context.Dispose();
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
