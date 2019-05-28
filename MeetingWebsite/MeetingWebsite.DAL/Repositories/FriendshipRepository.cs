using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class FriendshipRepository : IRepository<Friendship>
    {
        private readonly MeetingDbContext _db;

        public FriendshipRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Friendship> GetAll()
        {
            throw new NotImplementedException();
        }

        public Friendship Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friendship> Find(Func<Friendship, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Friendship item)
        {
            throw new NotImplementedException();
        }

        public void Update(Friendship item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}