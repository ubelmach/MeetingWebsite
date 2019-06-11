using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class Interests
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual List<UserInterests> UserInterests { get; set; }

        public Interests()
        {
            UserInterests = new List<UserInterests>();
        }

    }
}