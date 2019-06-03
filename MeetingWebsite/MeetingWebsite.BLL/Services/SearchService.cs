using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class SearchService : ISearchService
    {
        private MeetingDbContext _db;
        public IUnitOfWork _database;

        public SearchService(IUnitOfWork database,
            MeetingDbContext db)
        {
            _database = database;
            _db = db;
        }

        public IEnumerable<User> FindUsers(SearchByCriteriaViewModel criteria)
        {
            IQueryable<User> result = null;
            if (criteria == null)
                return null;

            if (!string.IsNullOrEmpty(criteria.Age.ToString()))
                result = _database.UserRepository.Find(x => x.Birthday.Ticks == criteria.Age);

            if (!string.IsNullOrEmpty(criteria.Gender))
                result = _database.UserRepository.Find(x => x.Gender.ToString().Contains(criteria.Gender));

            if (!string.IsNullOrEmpty(criteria.PurposeOfDating))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.PurposeOfDating.Contains(criteria.PurposeOfDating));

            if (!string.IsNullOrEmpty(criteria.MaritalStatus))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.MaritalStatus.Contains(criteria.MaritalStatus));

            if (!string.IsNullOrEmpty(criteria.Height))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.Height.Contains(criteria.Height));

            if (!string.IsNullOrEmpty(criteria.Weight))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.Weight.Contains(criteria.Weight));

            if (!string.IsNullOrEmpty(criteria.Education))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.Education.Contains(criteria.Education));

            if (!string.IsNullOrEmpty(criteria.Nationality))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.Nationality.Contains(criteria.Nationality));

            if (!string.IsNullOrEmpty(criteria.ZodiacSign))
                result = _database.UserRepository.Find(x => x.UserProfile.ZodiacSign.ToString().Contains(criteria.ZodiacSign));

            if (!string.IsNullOrEmpty(criteria.KnowledgeOfLanguages))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.KnowledgeOfLanguages.Contains(criteria.KnowledgeOfLanguages));

            if (!string.IsNullOrEmpty(criteria.FinancialSituation))
                result = _database.UserRepository.Find(x =>
                    x.UserProfile.FinancialSituation.Contains(criteria.FinancialSituation));
            return result;
        }
    }
}