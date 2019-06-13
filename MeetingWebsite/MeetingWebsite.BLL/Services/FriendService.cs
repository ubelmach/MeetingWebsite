using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _database;

        public FriendService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<Friendship> FindFriendCurrentUser(string userId)
        {
            var friend = _database.FriendRepository
                .Find(x =>
                    x.InviteStatus == InviteStatuses.Accepted &&
                           x.FirstFriendId == userId ||
                           x.SecondFriendId == userId);

            return friend;
        }

        public Friendship SendRequest(SendFriendRequestViewModel request)
        {
            var friendship = _database.FriendRepository.Find(x =>
                x.FirstFriendId == request.WhoSendsRequest &&
                x.SecondFriendId == request.WhoReceivesRequest ||
                x.FirstFriendId == request.WhoReceivesRequest &&
                x.SecondFriendId == request.WhoSendsRequest);

            if (friendship.Any())
                return null;

            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Friendship> FindNewRequests(string userId)
        {
            var newRequests = _database.FriendRepository
                .Find(x => x.SecondFriendId == userId &&
                           x.InviteStatus == InviteStatuses.WaitingForApprovals);

            return newRequests;
        }

        public Friendship Accepted(int id)
        {
            var findRequest = _database.FriendRepository.Get(id);
            findRequest.InviteStatus = InviteStatuses.Accepted;

            _database.FriendRepository.Update(findRequest);
            _database.Save();
            return findRequest;
        }

        public Friendship Rejected(int id)
        {
            var findRequest = _database.FriendRepository.Get(id);
            findRequest.InviteStatus = InviteStatuses.Rejected;

            _database.FriendRepository.Update(findRequest);
            _database.Save();
            return findRequest;
        }
    }
}