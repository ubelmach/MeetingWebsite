using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeetingWebsite.Models.EntityEnums;
using Microsoft.AspNetCore.Identity;

namespace MeetingWebsite.Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }

        public string PurposeOfDating { get; set; }
        //public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Education { get; set; }
        public string Nationality { get; set; }
        public ZodiacSigns ZodiacSign { get; set; }
        public string KnowledgeOfLanguages { get; set; }
        public string BadHabits { get; set; }
        public string FinancialSituation { get; set; }
        public string Interests { get; set; }

        public bool AnonymityMode { get; set; }

        [NotMapped]
        public virtual List<Friendship> IncomingFriendships { get; set; }

        [NotMapped]
        public virtual List<Friendship> OutgoingFriendships { get; set; }

        [NotMapped]
        public virtual List<Message> IncomingMessages { get; set; }

        [NotMapped]
        public virtual List<Message> OutgoingMessages { get; set; }

        [NotMapped]
        public virtual List<BlackList> WhomTheUserAdded { get; set; }

        [NotMapped]
        public virtual List<BlackList> WhoAddedCurrentUser { get; set; }

        [NotMapped]
        public virtual File Avatar { get; set; }
    }
}