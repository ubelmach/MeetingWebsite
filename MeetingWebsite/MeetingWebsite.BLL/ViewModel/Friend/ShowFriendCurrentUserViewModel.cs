using MeetingWebsite.Models.Entities;
using System;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowFriendCurrentUserViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public string Avatar { get; set; }

        public ShowFriendCurrentUserViewModel(string userId, Friendship friend)
        {
            if (friend.FirstFriendId == userId)
            {
                UserId = userId;
                FirstName = friend.SecondFriend.FirstName;
                LastName = friend.SecondFriend.LastName;
                Age = DateTime.Today.Year - friend.SecondFriend.Birthday.Year;

                if (friend.SecondFriend.Avatar != null)
                {
                    Avatar = friend.SecondFriend.HomeDir
                             + friend.SecondFriend.Avatar.Path;
                }
                else
                {
                    Avatar = "/File/Nophoto.jpg";
                }
            }

            else
            {
                UserId = userId;
                FirstName = friend.FirstFriend.FirstName;
                LastName = friend.FirstFriend.LastName;
                Age = DateTime.Today.Year - friend.FirstFriend.Birthday.Year;

                if (friend.FirstFriend.Avatar != null)
                {
                    Avatar = friend.FirstFriend.HomeDir
                             + friend.FirstFriend.Avatar.Path;
                }
                else
                {
                    Avatar = "/File/Nophoto.jpg";
                }
            }
        }
    }
}