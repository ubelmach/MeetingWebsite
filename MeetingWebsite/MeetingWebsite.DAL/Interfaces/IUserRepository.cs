using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(string id);
        IQueryable<User> Find(Expression<Func<User, bool>> predicate);
        void Update(User item);
        User Delete(int id);
    }
}