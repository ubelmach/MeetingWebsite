﻿using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class BlacklistRepository : IRepository<BlackList>
    {
        private MeetingDbContext _db;

        public BlacklistRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<BlackList> Find(Func<BlackList, bool> predicate)
        {
            return _db.BlackLists.Where(predicate);
        }

        public void Create(BlackList newBlackList)
        {
            _db.BlackLists.Add(newBlackList);
        }

        public void Delete(int id)
        {
            var delete = _db.BlackLists.Find(id);
            if (delete != null)
                _db.BlackLists.Remove(delete);
        }

        public IEnumerable<BlackList> GetAll()
        {
            throw new NotImplementedException();
        }

        public BlackList Get(int id)
        {
            return _db.BlackLists.Find(id);
        }

        public void Update(BlackList item)
        {
            throw new NotImplementedException();
        }
    }
}