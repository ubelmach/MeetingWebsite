using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IFriendService
    {
        Task<List<Friendship>> FindFriendCurrentUser(string userId);
        Friendship MoveRequest(int friendId, string userId);
        Friendship SendRequest(SendFriendRequestViewModel request);
        IEnumerable<Friendship> FindNewRequests(string userId);
        void Accepted(int id);
        void Rejected(int id);
    }
}