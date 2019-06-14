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
        private readonly IAccountService _accountService;

        public FriendService(IUnitOfWork database,
            IAccountService accountService)
        {
            _database = database;
            _accountService = accountService;
        }

        public IEnumerable<Friendship> FindFriendCurrentUser(string userId)
        {
            return _database.FriendRepository
                .Find(x =>
                    x.InviteStatus == InviteStatuses.Accepted &&
                           x.FirstFriendId == userId ||
                    x.InviteStatus == InviteStatuses.Accepted &&
                           x.SecondFriendId == userId);

        }

        public Friendship MoveRequest(int friendId, string userId)
        {
            var friendship = _database.FriendRepository.Get(friendId);
            if (friendship == null)
            {
                return null;
            }

            if (friendship.FirstFriendId == userId)
            {
                friendship.FirstFriendId = friendship.SecondFriend.Id;
                friendship.SecondFriendId = userId;
                friendship.InviteStatus = InviteStatuses.WaitingForApprovals;
            }
            else
            {
                friendship.FirstFriendId = userId;
                friendship.SecondFriendId = friendship.SecondFriend.Id;
                friendship.InviteStatus = InviteStatuses.WaitingForApprovals;
            }

            _database.FriendRepository.Update(friendship);
            _database.Save();

            //if (friend.FirstFriendId == userId)
            //{
            //    UserId = userId;
            //    FirstName = friend.SecondFriend.FirstName;
            //    LastName = friend.SecondFriend.LastName;
            //    Age = DateTime.Today.Year - friend.SecondFriend.Birthday.Year;

            //    if (friend.SecondFriend.Avatar != null)
            //    {
            //        Avatar = friend.SecondFriend.HomeDir
            //                 + friend.SecondFriend.Avatar.Path;
            //        Avatar = friend.HomeDir + friend.Avatar.Path;
            //    }
            //    else
            //    {
            //        Avatar = "/File/Nophoto.jpg";
            //    }
            //}


            //else
            //{
            //    UserId = userId;
            //    FirstName = friend.FirstFriend.FirstName;
            //    LastName = friend.FirstFriend.LastName;
            //    Age = DateTime.Today.Year - friend.FirstFriend.Birthday.Year;

            //    if (friend.FirstFriend.Avatar != null)
            //    {
            //        Avatar = friend.FirstFriend.HomeDir
            //                 + friend.FirstFriend.Avatar.Path;
            //    }
            //    else
            //    {
            //        Avatar = "/File/Nophoto.jpg";
            //    }
            //}

            return null;
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