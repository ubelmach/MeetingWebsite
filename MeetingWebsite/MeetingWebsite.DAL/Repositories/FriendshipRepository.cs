using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _db.Friendships.Find(id);
        }

        public IEnumerable<Friendship> Find(Func<Friendship, bool> predicate)
        {
            return _db.Friendships.Where(predicate);
        }

        public void Create(Friendship item)
        {
            _db.Friendships.Add(item);
        }

        public void Update(Friendship item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var friend = _db.Friendships.Find(id);
            if (friend != null)
                _db.Friendships.Remove(friend);
        }
    }
}