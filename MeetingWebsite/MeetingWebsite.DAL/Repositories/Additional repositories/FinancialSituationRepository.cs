using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class FinancialSituationRepository : IRepository<FinancialSituation>
    {
        public MeetingDbContext _db;

        public FinancialSituationRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<FinancialSituation> GetAll()
        {
            return _db.FinancialSituations;
        }

        public FinancialSituation Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FinancialSituation> Find(Func<FinancialSituation, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(FinancialSituation item)
        {
            throw new NotImplementedException();
        }

        public void Update(FinancialSituation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}