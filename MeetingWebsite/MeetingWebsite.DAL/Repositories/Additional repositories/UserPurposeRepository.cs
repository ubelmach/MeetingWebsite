using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class UserPurposeRepository : IRepository<UserPurpose>
    {
        private MeetingDbContext _db;

        public UserPurposeRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<UserPurpose> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserPurpose Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPurpose> Find(Func<UserPurpose, bool> predicate)
        {
            return _db.UserPurposes.Where(predicate);
        }

        public void Create(UserPurpose item)
        {
            _db.UserPurposes.AddRange(item);
        }

        public void Update(UserPurpose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var purpose = _db.UserPurposes.Find(id);
            if (purpose != null)
                _db.UserPurposes.Remove(purpose);
        }
    }
}