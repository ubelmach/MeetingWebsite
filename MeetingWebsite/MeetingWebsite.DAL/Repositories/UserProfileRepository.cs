using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class UserProfileRepository : IRepository<UserProfile>
    {
        private MeetingDbContext _db;

        public UserProfileRepository(MeetingDbContext db)
        {
            _db = db;
        }

        public IEnumerable<UserProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserProfile Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(UserProfile item)
        {
            _db.UserProfiles.AddRange(item);
        }

        public void Update(UserProfile item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}