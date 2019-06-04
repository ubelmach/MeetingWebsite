using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MeetingDbContext _db;

        public UserRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(string id)
        {
            return _db.Users.Find(id);
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _db.Users.Where(predicate);
        }

        public void Update(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public User Delete(int id)
        {
            return _db.Users.Find(id);
        }
    }
}