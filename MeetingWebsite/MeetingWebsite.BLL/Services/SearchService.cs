using System;
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

        public IQueryable<User> FindUsers(SearchByCriteriaViewModel criteria)
        {
            var users = _database.UserRepository.GetAll();
            if (users == null)
                return null;

            var today = DateTime.Today;
            if (!string.IsNullOrEmpty(criteria.AgeFrom.ToString()) &&
                !string.IsNullOrEmpty(criteria.AgeTo.ToString()))
                users = _database.UserRepository.Find(x => (today.Year - x.Birthday.Year) <= criteria.AgeTo && (today.Year - x.Birthday.Year) >= criteria.AgeFrom);

            if(!string.IsNullOrEmpty(criteria.Height.ToString()))
                users = 



            //if (!string.IsNullOrEmpty(criteria.Gender))
            //    result = _database.UserRepository.Find(x => x.Gender.ToString().Contains(criteria.Gender));

            //if (!string.IsNullOrEmpty(criteria.PurposeOfDating))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.PurposeOfDating.Contains(criteria.PurposeOfDating));

            //if (!string.IsNullOrEmpty(criteria.MaritalStatus))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.MaritalStatus.Contains(criteria.MaritalStatus));

            //if (!string.IsNullOrEmpty(criteria.Height))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.Height.Contains(criteria.Height));

            //if (!string.IsNullOrEmpty(criteria.Weight))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.Weight.Contains(criteria.Weight));

            //if (!string.IsNullOrEmpty(criteria.Education))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.Education.Contains(criteria.Education));

            //if (!string.IsNullOrEmpty(criteria.Nationality))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.Nationality.Contains(criteria.Nationality));

            //if (!string.IsNullOrEmpty(criteria.ZodiacSign))
            //    result = _database.UserRepository.Find(x => x.UserProfile.ZodiacSign.ToString().Contains(criteria.ZodiacSign));

            //if (!string.IsNullOrEmpty(criteria.KnowledgeOfLanguages))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.KnowledgeOfLanguages.Contains(criteria.KnowledgeOfLanguages));

            //if (!string.IsNullOrEmpty(criteria.FinancialSituation))
            //    result = _database.UserRepository.Find(x =>
            //        x.UserProfile.FinancialSituation.Contains(criteria.FinancialSituation));
            //return result;

            return users;
        }
    }
}