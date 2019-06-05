using System;
using System.Globalization;
using MeetingWebsite.Models.Entities;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.BLL.ViewModel
{
    public class EditUserProfileInformation
    {
        public string Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }
        public string PurposeOfDating { get; set; }
        public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Education { get; set; }
        public string Nationality { get; set; }
        public string ZodiacSign { get; set; }
        public string KnowledgeOfLanguages { get; set; }
        public string BadHabits { get; set; }
        public string FinancialSituation { get; set; }
        public string Interests { get; set; }

        public bool AnonymityMode { get; set; }

        public EditUserProfileInformation() { }

        public EditUserProfileInformation(User user)
        {
            Id = user.Id;

            if (!string.IsNullOrEmpty(user.FirstName))
            { Firstname = user.FirstName; }
            if (!string.IsNullOrEmpty(user.LastName))
            { Lastname = user.LastName; }
            if (!string.IsNullOrEmpty(user.Gender.ToString()))
            { Gender = user.Gender; }
            if (!string.IsNullOrEmpty(user.Birthday.ToString(CultureInfo.InvariantCulture)))
            { Birthday = user.Birthday; }
            if (!string.IsNullOrEmpty(user.UserProfile.ZodiacSign))
            { ZodiacSign = user.UserProfile.ZodiacSign; }
            if (!string.IsNullOrEmpty(user.UserProfile.PurposeOfDating))
            { PurposeOfDating = user.UserProfile.PurposeOfDating; }
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
            if (!string.IsNullOrEmpty(user.UserProfile.KnowledgeOfLanguages))
            { KnowledgeOfLanguages = user.UserProfile.KnowledgeOfLanguages; }
            if (!string.IsNullOrEmpty(user.UserProfile.BadHabits))
            { BadHabits = user.UserProfile.BadHabits; }
            if (!string.IsNullOrEmpty(user.UserProfile.FinancialSituation))
            { FinancialSituation = user.UserProfile.FinancialSituation; }
            if (!string.IsNullOrEmpty(user.UserProfile.Interests))
            { Interests = user.UserProfile.Interests; }
            AnonymityMode = user.AnonymityMode;
        }
    }
}