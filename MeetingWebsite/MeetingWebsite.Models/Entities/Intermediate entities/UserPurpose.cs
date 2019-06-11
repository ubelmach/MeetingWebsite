using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class UserPurpose
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [ForeignKey("PurposeOfDating")]
        public int PurposeId { get; set; }
        public virtual PurposeOfDating PurposeOfDating { get; set; }
    }
}