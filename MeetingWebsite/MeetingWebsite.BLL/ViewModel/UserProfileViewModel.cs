using MeetingWebsite.Models.EntityEnums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.BLL.ViewModel
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }
        public bool AnonymityMode { get; set; }

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

        public string Avatar { get; set; }
    }
}