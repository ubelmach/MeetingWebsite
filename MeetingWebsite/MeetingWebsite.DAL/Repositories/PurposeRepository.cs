using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class PurposeRepository : IRepository<PurposeOfDating>
    {
        private MeetingDbContext _db;

        public PurposeRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(PurposeOfDating item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurposeOfDating> Find(Func<PurposeOfDating, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public PurposeOfDating Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurposeOfDating> GetAll()
        {
            return _db.PurposeOfDatings;
        }

        public void Update(PurposeOfDating item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}