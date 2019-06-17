using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _database;
        private readonly IAccountService _accountService;

        public FriendService(IUnitOfWork database,
            IAccountService accountService)
        {
            _database = database;
            _accountService = accountService;
        }

        public async Task<List<Friendship>> FindFriendCurrentUser(string userId)
        {
            var user = await _accountService.GetUser(userId);

            var incomingFriendships = user.IncomingFriendships
                .Where(x => x.InviteStatus == InviteStatuses.Accepted &&
                            x.SecondFriendId == userId);

            var outgoingFriendships = user.OutgoingFriendships
                .Where(x => x.InviteStatus == InviteStatuses.Accepted &&
                            x.FirstFriendId == userId);

            var fullList = new List<Friendship>();
            fullList.AddRange(incomingFriendships);
            fullList.AddRange(outgoingFriendships);

            return !fullList.Any() ? null : fullList;
        }

        public Friendship MoveRequest(int friendshipId, string userId)
        {
            var friendship = _database.FriendRepository.Get(friendshipId);
            if (friendship == null)
            {
                return null;
            }

            var moveRequest = Friendship.Test(userId, friendship);
            _database.FriendRepository.Update(moveRequest);
            _database.Save();

            return friendship;
        }

        public Friendship SendRequest(SendFriendRequestViewModel request)
        {
            var friendship = _database.FriendRepository.Find(x =>
                x.FirstFriendId == request.WhoSendsRequest &&
                x.SecondFriendId == request.WhoReceivesRequest ||
                x.FirstFriendId == request.WhoReceivesRequest &&
                x.SecondFriendId == request.WhoSendsRequest);

            if (friendship.Any())
            {
                return null;
            }

            var newRequest = new Friendship
            {
                FirstFriendId = request.WhoSendsRequest,
                SecondFriendId = request.WhoReceivesRequest,
                InviteStatus = InviteStatuses.WaitingForApprovals
            };

            _database.FriendRepository.Create(newRequest);
            _database.Save();
            return newRequest;
        }



        public IEnumerable<Friendship> FindNewRequests(string userId)
        {
            return _database.FriendRepository
                .Find(x => x.SecondFriendId == userId &&
                           x.InviteStatus == InviteStatuses.WaitingForApprovals);
        }

        public void Accepted(int id)
        {
            var findRequest = _database.FriendRepository.Get(id);
            findRequest.InviteStatus = InviteStatuses.Accepted;

            _database.FriendRepository.Update(findRequest);
            _database.Save();
        }

        public void Rejected(int id)
        {
            _database.FriendRepository.Delete(id);
            _database.Save();
        }
    }
}