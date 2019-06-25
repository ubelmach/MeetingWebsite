using System.Linq;
using MeetingWebsite.BLL.Helpers;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class SearchService : ISearchService
    {
        public IUnitOfWork Database;

        public SearchService(IUnitOfWork database)
        {
            Database = database;
        }

        public IQueryable<User> FindUsers(SearchByCriteriaViewModel criteria)
        {
            var users = Database.UserRepository.GetAll();
            if (users == null)
            {
                return null;
            }

            users = users.Where(x => x.Id != criteria.CurrentUserId && x.AnonymityMode == false);
            users = users.FilterBy(SearchHelper.AgeCriteria, criteria.AgeFrom, criteria.AgeTo);
            users = users.FilterBy(SearchHelper.HeightCriteria, criteria.HeightFrom, criteria.HeightTo);
            users = users.FilterBy(SearchHelper.WeightCriteria, criteria.WeightFrom, criteria.WeightTo);
            users = users.FilterBy(SearchHelper.GenderCriteria, criteria.Genders);
            users = users.FilterBy(SearchHelper.EducationCriteria, criteria.Education);
            users = users.FilterBy(SearchHelper.NationalityCriteria, criteria.Nationality);
            users = users.FilterBy(SearchHelper.FinancialSituationCriteria, criteria.FinancialSituation);
            users = users.FilterBy(SearchHelper.ZodiacSignCriteria, criteria.ZodiacSign);
            users = users.FilterByMultipleChoice(SearchHelper.PurposeOfDatingCriteria, criteria.PurposeOfDating);
            users = users.FilterByMultipleChoice(SearchHelper.KnowledgeOfLanguagesCriteria, criteria.KnowledgeOfLanguages);
            users = users.FilterByMultipleChoice(SearchHelper.BadHabitsCriteria, criteria.BadHabits);
            users = users.FilterByMultipleChoice(SearchHelper.PurposeOfDatingCriteria, criteria.Interests);

            return users;
        }
    }
}