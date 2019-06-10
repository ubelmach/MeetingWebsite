using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class UserLanguages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [ForeignKey("Languages")]
        public int LanguageId { get; set; }
        public virtual Languages Languages { get; set; }
    }
}