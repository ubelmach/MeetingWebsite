using MeetingWebsite.Models.Entities;
using System;
using System.Collections.Generic;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowFriendViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public string Avatar { get; set; }
        public int FriendshipId { get; set; }
        public string FriendId { get; set; }

        public ShowFriendViewModel(string userId, int friendshipId, User user)
        {
            UserId = userId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = DateTime.Today.Year - user.Birthday.Year;

            if (user.Avatar != null)
            {
                Avatar = user.HomeDir + user.Avatar.Path;
            }
            else
            {
                Avatar = "/File/Nophoto.jpg";
            }

            FriendId = user.Id;
            FriendshipId = friendshipId;
        }

        public static IEnumerable<ShowFriendViewModel> MapToViewModels(string userId, IEnumerable<Friendship> friendships)
        {
            foreach (var friendship in friendships)
            {
                yield return friendship.FirstFriendId == userId
                    ? new ShowFriendViewModel(userId, friendship.Id, friendship.SecondFriend)
                    : new ShowFriendViewModel(userId, friendship.Id, friendship.FirstFriend);
            }
        }
    }
}