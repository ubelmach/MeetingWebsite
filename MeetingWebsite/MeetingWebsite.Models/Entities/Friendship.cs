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

        public Friendship() { }

        public static Friendship Update(string userId, Friendship friendship, User user)
        {
            friendship.FirstFriendId = user.Id;
            friendship.SecondFriendId = userId;
            friendship.InviteStatus = InviteStatuses.WaitingForApprovals;

            return friendship;
        }

        public static Friendship Test(string userId, Friendship friendship)
        {
            return friendship.FirstFriendId == userId
                ? Update(userId, friendship, friendship.SecondFriend)
                : Update(userId, friendship, friendship.FirstFriend);
        }
    }
}