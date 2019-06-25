using System;
using System.Linq;
using MeetingWebsite.BLL.Helpers;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.SignalR;

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
            //users = users.FilterBy(SearchHelper.AgeCriteria, criteria.AgeFrom, criteria.AgeTo);
            //users = users.FilterBy(SearchHelper.HeightCriteria, criteria.HeightFrom, criteria.HeightTo);
            //users = users.FilterBy(SearchHelper.WeightCriteria, criteria.WeightFrom, criteria.WeightTo);
            //users = users.FilterBy(SearchHelper.GenderCriteria, criteria.Genders);
            //users = users.FilterBy(SearchHelper.EducationCriteria, criteria.Education);
            //users = users.FilterBy(SearchHelper.NationalityCriteria, criteria.Nationality);
            //users = users.FilterBy(SearchHelper.FinancialSituationCriteria, criteria.FinancialSituation);
            //users = users.FilterBy(SearchHelper.ZodiacSignCriteria, criteria.ZodiacSign);
            //users = users.FilterByMultipleChoice(SearchHelper.PurposeOfDatingCriteria, criteria.PurposeOfDating);
            //users = users.FilterByMultipleChoice(SearchHelper.KnowledgeOfLanguagesCriteria, criteria.KnowledgeOfLanguages);
            //users = users.FilterByMultipleChoice(SearchHelper.BadHabitsCriteria, criteria.BadHabits);
            //users = users.FilterByMultipleChoice(SearchHelper.PurposeOfDatingCriteria, criteria.Interests);

            if (!string.IsNullOrEmpty(criteria.AgeFrom.ToString()) &&
                !string.IsNullOrEmpty(criteria.AgeTo.ToString()))
                users = users.Where(x =>
                    (DateTime.Today.Year - x.Birthday.Year) <= criteria.AgeTo &&
                    (DateTime.Today.Year - x.Birthday.Year) >= criteria.AgeFrom);

            if (!string.IsNullOrEmpty(criteria.HeightFrom.ToString()) &&
                !string.IsNullOrEmpty(criteria.HeightTo.ToString()))
                users = users.Where(x =>
                    Convert.ToInt32(x.UserProfile.Height) <= criteria.HeightTo &&
                    Convert.ToInt32(x.UserProfile.Height) >= criteria.HeightFrom);

            if (!string.IsNullOrEmpty(criteria.WeightFrom.ToString()) &&
                !string.IsNullOrEmpty(criteria.WeightTo.ToString()))
                users = users.Where(x =>
                    Convert.ToInt32(x.UserProfile.Weight) <= criteria.WeightTo &&
                    Convert.ToInt32(x.UserProfile.Weight) >= criteria.WeightFrom);

            if (!string.IsNullOrEmpty(criteria.Genders.ToString()))
                users = users.Where(x =>
                    x.GenderId == criteria.Genders);

            if (criteria.Education != null)
                users = users.Where(x =>
                    criteria.Education.Contains(x.UserProfile.EducationId.Value));

            if (criteria.Nationality != null)
                users = users.Where(x =>
                    criteria.Nationality.Contains(x.UserProfile.FinancialSituationId.Value));

            if (criteria.FinancialSituation != null)
                users = users.Where(x =>
                    criteria.FinancialSituation.Contains(x.UserProfile.FinancialSituationId.Value));

            if (criteria.ZodiacSign != null)
                users = users.Where(x =>
                    criteria.ZodiacSign.Contains(x.UserProfile.ZodiacSignId.Value));

            if (criteria.PurposeOfDating != null)
            {
                users = users.Where(user =>
                    user.UserProfile.UserPurposes
                        .Select(purpose => purpose.PurposeId)
                        .Intersect(criteria.PurposeOfDating)
                        .Any());
            }

            if (criteria.KnowledgeOfLanguages != null)
            {
                users = users.Where(user =>
                    user.UserProfile.UserLanguages
                        .Select(language => language.LanguageId)
                        .Intersect(criteria.KnowledgeOfLanguages)
                        .Any());
            }

            if (criteria.BadHabits != null)
            {
                users = users.Where(user =>
                    user.UserProfile.UserBadHabits
                        .Select(badHabit => badHabit.BadHabitsId)
                        .Intersect(criteria.BadHabits)
                        .Any());
            }

            if (criteria.Interests != null)
            {
                users = users.Where(user =>
                    user.UserProfile.UserInterests
                        .Select(interest => interest.InterestsId)
                        .Intersect(criteria.Interests)
                        .Any());
            }

            return users;
        }
    }
}