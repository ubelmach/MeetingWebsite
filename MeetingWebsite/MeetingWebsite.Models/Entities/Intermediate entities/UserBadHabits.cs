using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class UserBadHabits
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [ForeignKey("BadHabits")]
        public int BadHabitsId { get; set; }
        public virtual BadHabits BadHabits { get; set; }
    }
}