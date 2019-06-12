using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class GenderRepository : IRepository<Gender>
    {
        public MeetingDbContext _db;

        public GenderRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Gender> GetAll()
        {
            return _db.Genders;
        }

        public Gender Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> Find(Func<Gender, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Gender item)
        {
            throw new NotImplementedException();
        }

        public void Update(Gender item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}