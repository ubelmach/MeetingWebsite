using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class BlacklistService : IBlacklistService
    {
        public IUnitOfWork _database { get; set; }

        public BlacklistService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<BlackList> GetListUsersInBlackList(string userId)
        {
            return _database.BlacklistRepository.Find(x => x.CurrentUserId == userId);
        }

        public BlackList AddUserInBlackList(AddUserInBlackListViewModel addInBlackList)
        {
            try
            {
                var addUserInBlackList = new BlackList
                {
                    CurrentUserId = addInBlackList.CurrentUserId,
                    WhomId = addInBlackList.WhomId,
                    Date = addInBlackList.Date
                };

                _database.BlacklistRepository.Create(addUserInBlackList);
                _database.Save();
                return addUserInBlackList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BlackList FindBlackList(DeleteUserFromBlackListViewModel delete)
        {
            return _database.BlacklistRepository
                .Find(x => x.CurrentUserId == delete.CurrentUserId
                                && x.WhomId == delete.WhomId).First();
        }

        public void DeleteFromBlackList(int id)
        {
            _database.BlacklistRepository.Delete(id);
            _database.Save();
        }
    }
}