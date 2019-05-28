using System;
using System.Collections.Generic;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IFileRepository<T> where T : class
    {
        void Create(T item);
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}