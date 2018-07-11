using System;
using Microsoft.EntityFrameworkCore;
using SimpleChat.Business.Logic.Models;

namespace SimpleChat.External.RepositoryR
{
    public class Context : DbContext
    {
        string connectionString;
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Message> Messages { get; set; }

        public Context(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
