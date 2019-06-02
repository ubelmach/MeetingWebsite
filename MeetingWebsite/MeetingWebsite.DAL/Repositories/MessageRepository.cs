using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly MeetingDbContext _db;

        public MessageRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> Find(Func<Message, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Message item)
        {
            throw new NotImplementedException();
        }

        public void Update(Message item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}