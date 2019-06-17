using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowInformationFriendViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Education { get; set; }
        public string Nationality { get; set; }
        public string ZodiacSign { get; set; }
        public string FinancialSituation { get; set; }
        public string Avatar { get; set; }
        public string HomeDir { get; set; }
        public List<string> PurposeOfDating { get; set; }
        public List<string> KnowledgeOfLanguages { get; set; }
        public List<string> BadHabits { get; set; }
        public List<string> Interests { get; set; }

        public ShowInformationFriendViewModel(User user)
        {
            Id = user.Id;

            if (!string.IsNullOrEmpty(user.FirstName))
            { FirstName = user.FirstName; }

            if (!string.IsNullOrEmpty(user.LastName))
            { LastName = user.LastName; }

            if (user.Gender != null)
            { Gender = user.Gender.Value; }

            if (!string.IsNullOrEmpty(user.Birthday.ToString(CultureInfo.InvariantCulture)))
            { Birthday = user.Birthday; }

            if (!string.IsNullOrEmpty(user.UserProfile.Height))
            { Height = user.UserProfile.Height; }

            if (!string.IsNullOrEmpty(user.UserProfile.Weight))
            { Weight = user.UserProfile.Weight; }

            if (user.UserProfile.Education != null)
            { Education = user.UserProfile.Education.Value; }

            if (user.UserProfile.Nationality != null)
            { Nationality = user.UserProfile.Nationality.Value; }

            if (user.UserProfile.ZodiacSign != null)
            { ZodiacSign = user.UserProfile.ZodiacSign.Value; }

            if (user.UserProfile.FinancialSituation != null)
            { FinancialSituation = user.UserProfile.FinancialSituation.Value; }

            if (!string.IsNullOrEmpty(user.HomeDir))
            { HomeDir = user.HomeDir; }

            if (user.Avatar != null)
            {
                Avatar = user.HomeDir + user.Avatar.Path;
            }
            else
            {
                Avatar = "/File/Nophoto.jpg";
            }

            var languages = new List<string>();
            if (user.UserProfile.UserLanguages.Any())
            {
                foreach (var language in user.UserProfile.UserLanguages)
                {
                    languages.Add(language.Languages.Value);
                }

                KnowledgeOfLanguages = languages;
            }

            var purposes = new List<string>();
            if (user.UserProfile.UserPurposes.Any())
            {
                foreach (var purpose in user.UserProfile.UserPurposes)
                {
                    purposes.Add(purpose.PurposeOfDating.Value);
                }

                PurposeOfDating = purposes;
            }

            var badHabits = new List<string>();
            if (user.UserProfile.UserBadHabits.Any())
            {
                foreach (var badHabit in user.UserProfile.UserBadHabits)
                {
                    badHabits.Add(badHabit.BadHabits.Value);
                }

                BadHabits = badHabits;
            }

            var interests = new List<string>();
            if (user.UserProfile.UserInterests.Any())
            {
                foreach (var interest in user.UserProfile.UserInterests)
                {
                    interests.Add(interest.Interests.Value);
                }

                Interests = interests;
            }
        }
    }
}