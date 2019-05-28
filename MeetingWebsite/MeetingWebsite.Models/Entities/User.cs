using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MeetingWebsite.Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PurposeOfDating { get; set; }
        public string Type { get; set; }
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
        public bool AnonymityMode { get; set;  }

        public virtual List<Friendship> Friendship { get; set; }
        public virtual List<Message> Message { get; set; }
        public virtual File File { get; set; }
    }
}