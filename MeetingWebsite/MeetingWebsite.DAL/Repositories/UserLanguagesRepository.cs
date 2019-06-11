using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class UserLanguagesRepository : IRepository<UserLanguages>
    {
        private MeetingDbContext _db;

        public UserLanguagesRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(UserLanguages item)
        {
            _db.UserLanguages.AddRange(item);
        }

        public void Delete(int id)
        {
            var language = _db.UserLanguages.Find(id);
            if (language != null)
                _db.UserLanguages.Remove(language);
        }

        public IEnumerable<UserLanguages> Find(Func<UserLanguages, bool> predicate)
        {
            return _db.UserLanguages.Where(predicate);
        }

        public UserLanguages Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLanguages> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserLanguages item)
        {
            throw new NotImplementedException();
        }
    }
}