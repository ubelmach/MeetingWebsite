using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class UserInterestsRepository : IRepository<UserInterests>
    {
        private MeetingDbContext _db;

        public UserInterestsRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<UserInterests> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserInterests Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInterests> Find(Func<UserInterests, bool> predicate)
        {
            return _db.UserInterests.Where(predicate);
        }

        public void Create(UserInterests item)
        {
            _db.UserInterests.AddRange(item);
        }

        public void Update(UserInterests item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var interests = _db.UserInterests.Find(id);
            if (interests != null)
                _db.UserInterests.Remove(interests);
        }
    }
}