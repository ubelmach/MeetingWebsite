using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class LanguageRepository : IRepository<Languages>
    {
        private MeetingDbContext _db;

        public LanguageRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(Languages item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Languages> Find(Func<Languages, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Languages Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Languages> GetAll()
        {
            return _db.Languageses;
        }

        public void Update(Languages item)
        {
            throw new NotImplementedException();
        }
    }
}