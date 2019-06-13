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
        public IUnitOfWork Database { get; set; }

        public BlacklistService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<BlackList> GetListUsersInBlackList(string userId)
        {
            return Database.BlacklistRepository.Find(x => x.CurrentUserId == userId);
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

                Database.BlacklistRepository.Create(addUserInBlackList);
                Database.Save();
                return addUserInBlackList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BlackList FindBlackList(DeleteUserFromBlackListViewModel delete)
        {
            return Database.BlacklistRepository
                .Find(x => x.CurrentUserId == delete.CurrentUserId
                                && x.WhomId == delete.WhomId).First();
        }

        public void DeleteFromBlackList(int id)
        {
            Database.BlacklistRepository.Delete(id);
            Database.Save();
        }
    }
}