using System;
using System.Collections.Generic;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Update(T item);
        void Delete(int id);
    }
}