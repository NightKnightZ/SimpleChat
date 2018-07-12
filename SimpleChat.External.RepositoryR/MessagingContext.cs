using System;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Messaging.Entities;
using SimpleChat.Messaging.Database.Sqlite.Interfaces;
namespace SimpleChat.Messaging.Database.Sqlite
{
    public class MessagingContext : DbContext
    {
        IDatabaseSettings dbSettings;
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        public MessagingContext(IDatabaseSettings dbSettings)
        {
            this.dbSettings = dbSettings ?? throw new ArgumentNullException(nameof(dbSettings));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(dbSettings.ConnectionString);
        }


    }
}
