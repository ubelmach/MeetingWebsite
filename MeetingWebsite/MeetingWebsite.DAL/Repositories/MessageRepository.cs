using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _db.Messages;
        }

        public Message Get(int id)
        {
            return _db.Messages.Find(id);
        }

        public IEnumerable<Message> Find(Func<Message, bool> predicate)
        {
            return _db.Messages.Where(predicate);
        }

        public void Create(Message item)
        {
            _db.Messages.Add(item);
        }

        public void Update(Message item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var message = _db.Messages.Find(id);
            if (message != null)
                _db.Messages.Remove(message); 
        }
    }
}