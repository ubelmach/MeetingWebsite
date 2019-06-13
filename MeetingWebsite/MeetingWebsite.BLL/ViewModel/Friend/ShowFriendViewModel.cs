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

        public ShowFriendViewModel(string userId, User user)
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
        }

        public static IEnumerable<ShowFriendViewModel> MapToViewModels(string userId, List<Friendship> friendships)
        {
            foreach (var friendship in friendships)
            {
                yield return friendship.FirstFriendId == userId
                    ? new ShowFriendViewModel(userId, friendship.FirstFriend)
                    : new ShowFriendViewModel(userId, friendship.SecondFriend);
            }
        }
    }
}