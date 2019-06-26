using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class BlacklistService : IBlacklistService
    {
        private readonly IUnitOfWork _database;
        private readonly IAccountService _accountService;
        private readonly IFriendService _friendService;

        public BlacklistService(IUnitOfWork database,
            IAccountService accountService,
            IFriendService friendService)
        {
            _database = database;
            _accountService = accountService;
            _friendService = friendService;
        }

        public async Task<List<BlackList>> GetListUsersInBlackList(string userId)
        {
            var badUser = await _accountService.GetUser(userId);
            var blackList = badUser.WhoAddedCurrentUser;
            return !blackList.Any() ? null : blackList;
        }

        public async Task<BlackList> AddUserInBlackList(AddUserInBlackListViewModel addInBlackList)
        {
            var badUser = await _accountService.GetUser(addInBlackList.WhomId);
            var incomingFriendships = badUser.IncomingFriendships
                .Where(x => x.FirstFriendId == addInBlackList.CurrentUserId &&
                            x.SecondFriendId == addInBlackList.WhomId)
                .ToList();
            var outgoingFriendships = badUser.OutgoingFriendships
                .Where(x => x.FirstFriendId == addInBlackList.WhomId &&
                            x.SecondFriendId == addInBlackList.CurrentUserId)
                .ToList();

            var fullList = incomingFriendships.Union(outgoingFriendships).ToList();

            var whomTheUserAdded = badUser.WhomTheUserAdded
                .Where(x => x.CurrentUserId == addInBlackList.CurrentUserId &&
                            x.WhomId == addInBlackList.WhomId)
                .ToList();

            if (whomTheUserAdded.Any())
            {
                return null;
            }

            BlackList addUserInBlackList;
            if (fullList.Any())
            {
                _friendService.Rejected(fullList.Select(x => x.Id).First());
                addUserInBlackList = new BlackList
                {
                    CurrentUserId = addInBlackList.CurrentUserId,
                    WhomId = addInBlackList.WhomId,
                    Date = addInBlackList.Date
                };
                _database.BlacklistRepository.Create(addUserInBlackList);
                _database.Save();

                return addUserInBlackList;
            }

            addUserInBlackList = new BlackList
            {
                CurrentUserId = addInBlackList.CurrentUserId,
                WhomId = addInBlackList.WhomId,
                Date = addInBlackList.Date
            };

            _database.BlacklistRepository.Create(addUserInBlackList);
            _database.Save();

            return addUserInBlackList;
        }

        public async Task<bool> CheckBlackList(string userId, string who)
        {
            var blacklist = await GetBlacklist(userId, who);
            return !blacklist.Any();
        }

        public async Task<bool> CheckBlacklistFromProfile(string userId, string who)
        {
            var blacklist = await GetBlacklist(userId, who);
            return blacklist.Any();
        }

        public async Task<bool> Check(string userId, string who)
        {
            var user = await _accountService.GetUser(userId);
            var test = user.WhomTheUserAdded
                .Where(x => x.CurrentUserId == who && x.WhomId == userId)
                .ToList();

            return test.Any();
        }

        public void DeleteFromBlackList(int id)
        {
            _database.BlacklistRepository.Delete(id);
            _database.Save();
        }

        public async Task<BlackList> FindUserInBlacklist(string userId, string who)
        {
            var user = await _accountService.GetUser(userId);

            var whomTheUserAdded = user.WhomTheUserAdded
                .Where(x => x.CurrentUserId == who && x.WhomId == userId)
                .ToList();
            var whoAddedCurrentUser = user.WhoAddedCurrentUser
                .Where(x => x.CurrentUserId == userId && x.WhomId == who)
                .ToList();
            var fillList = whomTheUserAdded.Union(whoAddedCurrentUser);

            return fillList.First();
        }

        private async Task<IEnumerable<BlackList>> GetBlacklist(string userId, string who)
        {
            var user = await _accountService.GetUser(userId);
            var blackList = user.WhoAddedCurrentUser.Where(x => x.CurrentUserId == userId && x.WhomId == who)
                .ToList();
            return blackList;
        }
    }
}