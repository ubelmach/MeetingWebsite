using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.Models.Entities
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FirstFriend")]
        public string FirstFriendId { get; set; }
        public virtual User FirstFriend { get; set; }

        [ForeignKey("SecondFriend")]
        public string SecondFriendId { get; set; }
        public virtual User SecondFriend { get; set; }

        public InviteStatuses InviteStatus { get; set; }
    }
}