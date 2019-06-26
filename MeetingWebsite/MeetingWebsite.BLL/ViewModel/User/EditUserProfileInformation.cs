using System;
using System.Collections.Generic;
using System.Globalization;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class EditUserProfileInformation
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public bool AnonymityMode { get; set; }
        public List<int> PurposeOfDating { get; set; }
        public List<int> KnowledgeOfLanguages { get; set; }
        public List<int> BadHabits { get; set; }
        public List<int> Interests { get; set; }
        public int Genders { get; set; }
        public int Education { get; set; }
        public int Nationality { get; set; }
        public int ZodiacSign { get; set; }
        public int FinancialSituation { get; set; }

        public EditUserProfileInformation() { }

        public EditUserProfileInformation(User user)
        {
            Id = user.Id;

            if (!string.IsNullOrEmpty(user.FirstName))
            { FirstName = user.FirstName; }

            if (!string.IsNullOrEmpty(user.LastName))
            { LastName = user.LastName; }

            if (!string.IsNullOrEmpty(user.Birthday.ToString(CultureInfo.InvariantCulture)))
            { Birthday = user.Birthday; }

            if (!string.IsNullOrEmpty(user.UserProfile.Height))
            { Height = user.UserProfile.Height; }

            if (!string.IsNullOrEmpty(user.UserProfile.Weight))
            { Weight = user.UserProfile.Weight; }

            AnonymityMode = user.AnonymityMode;
        }
    }
}