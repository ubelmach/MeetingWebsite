using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class UserBadHabitsRepository : IRepository<UserBadHabits>
    {
        private MeetingDbContext _db;

        public UserBadHabitsRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<UserBadHabits> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserBadHabits Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserBadHabits> Find(Func<UserBadHabits, bool> predicate)
        {
            return _db.UserBadHabits.Where(predicate);
        }

        public void Create(UserBadHabits item)
        {
            _db.UserBadHabits.AddRange(item);
        }

        public void Update(UserBadHabits item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var badHabits = _db.UserBadHabits.Find(id);
            if (badHabits != null)
                _db.UserBadHabits.Remove(badHabits);
        }
    }
}