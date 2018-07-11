using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleChat.Business.Logic.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T item);
        T GetItem(int id);
        void Update(T item);
        void DeleteItem(int id);
        void Save();
    }
}
