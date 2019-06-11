using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class InterestsRepository : IRepository<Interests>
    {
        private MeetingDbContext _db;

        public InterestsRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Interests> GetAll()
        {
            return _db.IteInterests;
        }

        public Interests Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interests> Find(Func<Interests, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Interests item)
        {
            throw new NotImplementedException();
        }

        public void Update(Interests item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}