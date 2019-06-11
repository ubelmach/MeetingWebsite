using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class UserInterests
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [ForeignKey("Interests")]
        public int InterestsId { get; set; }
        public virtual Interests Interests { get; set; }
    }
}