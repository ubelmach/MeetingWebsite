using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IFriendService
    {
        IEnumerable<Friendship> FindFriendCurrentUser(string userId);
        Friendship MoveRequest(int friendId, string userId);
        Friendship SendRequest(SendFriendRequestViewModel request);
        IEnumerable<Friendship> FindNewRequests(string userId);
        Friendship Accepted(int id);
        Friendship Rejected(int id);
    }
}