using MeetingWebsite.Models.EntityEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public bool AnonymityMode { get; set; }

        public string MaritalStatus { get; set; }
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

        public UserProfileViewModel(User user)
        {
            Id = user.Id;
            if (!string.IsNullOrEmpty(user.FirstName))
            { FirstName = user.FirstName; }
            if (!string.IsNullOrEmpty(user.LastName))
            { LastName = user.LastName; }
            if (!string.IsNullOrEmpty(user.Gender.ToString()))
            { Gender = user.Gender.ToString(); }
            if (!string.IsNullOrEmpty(user.Birthday.ToString(CultureInfo.InvariantCulture)))
            { Birthday = user.Birthday; }
            if (!string.IsNullOrEmpty(user.UserProfile.ZodiacSign.ToString()))
            { ZodiacSign = user.UserProfile.ZodiacSign.ToString(); }
            if (!string.IsNullOrEmpty(user.UserProfile.MaritalStatus))
            { MaritalStatus = user.UserProfile.MaritalStatus; }
            if (!string.IsNullOrEmpty(user.UserProfile.Height))
            { Height = user.UserProfile.Height; }
            if (!string.IsNullOrEmpty(user.UserProfile.Weight))
            { Weight = user.UserProfile.Weight; }
            if (!string.IsNullOrEmpty(user.UserProfile.Education))
            { Education = user.UserProfile.Education; }
            if (!string.IsNullOrEmpty(user.UserProfile.Nationality))
            { Nationality = user.UserProfile.Nationality; }
            if (!string.IsNullOrEmpty(user.UserProfile.FinancialSituation))
            { FinancialSituation = user.UserProfile.FinancialSituation; }
            AnonymityMode = user.AnonymityMode;

            if (!string.IsNullOrEmpty(user.HomeDir))
            {
                HomeDir = user.HomeDir;
            }

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