using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }

        //public virtual List<UserProfile> UserProfile { get; set; }
    }
}