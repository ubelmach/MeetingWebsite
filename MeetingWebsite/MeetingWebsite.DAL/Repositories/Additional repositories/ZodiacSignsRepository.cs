using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class ZodiacSignsRepository : IRepository<ZodiacSigns>
    {
        public MeetingDbContext _db;

        public ZodiacSignsRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(ZodiacSigns item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZodiacSigns> Find(Func<ZodiacSigns, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ZodiacSigns Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ZodiacSigns> GetAll()
        {
            return _db.ZodiacSigns;
        }

        public void Update(ZodiacSigns item)
        {
            throw new NotImplementedException();
        }
    }
}