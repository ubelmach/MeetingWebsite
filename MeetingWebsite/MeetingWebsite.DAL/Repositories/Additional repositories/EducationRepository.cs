using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class EducationRepository : IRepository<Education>
    {
        public MeetingDbContext _db;

        public EducationRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(Education item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Education> Find(Func<Education, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Education Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Education> GetAll()
        {
            return _db.Educations;
        }

        public void Update(Education item)
        {
            throw new NotImplementedException();
        }
    }
}