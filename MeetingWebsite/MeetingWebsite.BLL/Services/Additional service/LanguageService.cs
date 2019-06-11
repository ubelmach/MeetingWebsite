using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class LanguageService : ILanguageService
    {
        private IUnitOfWork _database;

        public LanguageService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<Languages> GetAll()
        {
            return _database.LanguageRepository.GetAll();
        }
    }
}