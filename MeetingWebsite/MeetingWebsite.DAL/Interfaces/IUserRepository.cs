using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T item);
        T Delete(int id);
    }
}