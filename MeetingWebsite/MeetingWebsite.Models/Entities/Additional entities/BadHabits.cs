using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class BadHabits
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual List<UserBadHabits> UserBadHabits { get; set; }

        public BadHabits()
        {
            UserBadHabits = new List<UserBadHabits>();
        }
    }
}