using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.Models.Entities
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public ZodiacSigns ZodiacSign { get; set; }
        public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Education { get; set; }
        public string Nationality { get; set; }
        public string FinancialSituation { get; set; }

        public virtual List<UserPurpose> UserPurposes { get; set; }
        public virtual List<UserLanguages> UserLanguages { get; set; }
        public virtual List<UserBadHabits> UserBadHabits { get; set; }
        public virtual List<UserInterests> UserInterests { get; set; }

        public UserProfile()
        {
            UserPurposes = new List<UserPurpose>();
            UserLanguages = new List<UserLanguages>();
            UserBadHabits = new List<UserBadHabits>();
            UserInterests = new List<UserInterests>();
        }
    }
}