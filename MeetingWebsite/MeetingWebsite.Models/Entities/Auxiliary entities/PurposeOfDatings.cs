using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class PurposeOfDating
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual List<UserPurpose> UserPurposes { get; set; }
        public PurposeOfDating()
        {
            UserPurposes = new List<UserPurpose>();
        }
    }
}