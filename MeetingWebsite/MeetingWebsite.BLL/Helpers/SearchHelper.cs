using MeetingWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingWebsite.BLL.Helpers
{
    public static class SearchHelper
    {
        public static IQueryable<User> FilterBy(this IQueryable<User> users, 
            Func<User, int> criteria, int? minValue, int? maxValue)
        {
            if(minValue.HasValue && maxValue.HasValue)
            {
                return users.Where(user => criteria(user) >= minValue &&
                criteria(user) <= maxValue);
            }

            return users;
        }

        public static IQueryable<User> FilterBy(this IQueryable<User> users, 
            Func<User, int> criteria, int? value)
        {
            if (value.HasValue)
            {
                return users.Where(user => criteria(user) == value);
            }

            return users;
        }

        public static IQueryable<User> FilterBy(this IQueryable<User> users,
            Func<User, int> criteria, IEnumerable<int> values)
        {
            if(values != null)
            {
                return users.Where(user => values.Contains(criteria(user)));
            }

            return users;
        }

        public static IQueryable<User> FilterBy(this IQueryable<User> users,
            Func<User, IEnumerable<int>> criteria, IEnumerable<int> values)
        {
            if(values!= null)
            {
                return users.Where(user => criteria(user).Intersect(values).Any());
            }

            return users;
        }

        public static int AgeCriteria(User user)
        {
            return DateTime.Today.Year - user.Birthday.Year;
        }

        public static int HeightCriteria(User user)
        {
            return Convert.ToInt32(user.UserProfile.Height);
        }

        public static int WeightCriteria(User user)
        {
            return Convert.ToInt32(user.UserProfile.Weight);
        }

        public static int GenderCriteria(User user)
        {
            return user.GenderId ?? -1;
        }

        public static int EducationCriteria(User user)
        {
            return user.UserProfile.EducationId ?? -1;
        }

        public static int NationalityCriteria(User user)
        {
            return user.UserProfile.NationalityId ?? -1;
        }

        public static int FinancialSituationCriteria(User user)
        {
            return user.UserProfile.FinancialSituationId ?? -1;
        }

        public static int ZodiacSignCriteria(User user)
        {
            return user.UserProfile.ZodiacSignId ?? -1;
        }

        public static IEnumerable<int> PurposeOfDatingCriteria(User user)
        {
            return user.UserProfile.UserPurposes
                .Select(purpose => purpose.Id).ToList();
        }

        public static IEnumerable<int> KnowledgeOfLanguagesCriteria(User user)
        {
            return user.UserProfile.UserLanguages
                        .Select(language => language.LanguageId);
        }

        public static IEnumerable<int> BadHabitsCriteria(User user)
        {
            return user.UserProfile.UserBadHabits
                        .Select(badHabit => badHabit.BadHabitsId);
        }

        public static IEnumerable<int> InterestsCriteria(User user)
        {
            return user.UserProfile.UserInterests
                        .Select(interest => interest.InterestsId);
        }
    }
}
