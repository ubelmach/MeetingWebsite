using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class FinancialSituationService : IFinancialSituationService
    {
        private IUnitOfWork _database;

        public FinancialSituationService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<FinancialSituation> GetAll()
        {
            return _database.FinancialSituationRepository.GetAll();
        }
    }
}