using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class BadHabitsRepository : IRepository<BadHabits>
    {
        private MeetingDbContext _db;
        public BadHabitsRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(BadHabits item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BadHabits> Find(Func<BadHabits, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public BadHabits Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BadHabits> GetAll()
        {
            return _db.BadHabits;
        }

        public void Update(BadHabits item)
        {
            throw new NotImplementedException();
        }
    }
}