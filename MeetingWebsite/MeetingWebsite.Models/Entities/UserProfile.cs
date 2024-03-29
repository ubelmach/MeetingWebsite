﻿using System.Collections.Generic;
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

        public string Height { get; set; }
        public string Weight { get; set; }

        [ForeignKey("Education")]
        public int? EducationId { get; set; }
        public virtual Education Education { get; set; }

        [ForeignKey("Nationality")]
        public int? NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        [ForeignKey("FinancialSituation")]
        public int? FinancialSituationId { get; set; }
        public virtual FinancialSituation FinancialSituation { get; set; }

        [ForeignKey("ZodiacSign")]
        public int? ZodiacSignId { get; set; }
        public virtual ZodiacSigns ZodiacSign { get; set; }

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