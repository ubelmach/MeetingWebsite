using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IFriendService
    {
        IEnumerable<Friendship> FindFriendCurrentUser(string userId);
        ShowInformationFriendViewModel ShowInformationFriend(Task<User> friend);
    }
}