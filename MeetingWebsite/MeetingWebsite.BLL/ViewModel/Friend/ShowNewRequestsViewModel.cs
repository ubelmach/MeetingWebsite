using System;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowNewRequestsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public string Avatar { get; set; }

        public ShowNewRequestsViewModel(Friendship friendship)
        {
            Id = friendship.Id;
            FirstName = friendship.FirstFriend.FirstName;
            LastName = friendship.FirstFriend.LastName;
            Age = DateTime.Today.Year - friendship.FirstFriend.Birthday.Year;

            if (friendship.FirstFriend.Avatar != null)
            {
                Avatar = friendship.FirstFriend.HomeDir
                         + friendship.FirstFriend.Avatar.Path;
            }
            else
            {
                Avatar = "/File/Nophoto.jpg";
            }
        }
    }
}