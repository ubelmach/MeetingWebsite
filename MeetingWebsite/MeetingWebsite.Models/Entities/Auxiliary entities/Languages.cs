using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class Languages
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual List<UserLanguages> UserLanguages { get; set; }

        public Languages()
        {
            UserLanguages = new List<UserLanguages>();
        }
    }
}