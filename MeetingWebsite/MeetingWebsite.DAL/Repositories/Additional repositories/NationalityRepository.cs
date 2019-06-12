using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class NationalityRepository : IRepository<Nationality>
    {
        public MeetingDbContext _db;

        public NationalityRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(Nationality item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nationality> Find(Func<Nationality, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Nationality Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nationality> GetAll()
        {
            return _db.Nationalities;
        }

        public void Update(Nationality item)
        {
            throw new NotImplementedException();
        }
    }
}