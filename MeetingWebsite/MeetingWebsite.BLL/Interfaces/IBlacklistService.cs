using System.Collections.Generic;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IBlacklistService
    {
        IEnumerable<BlackList> GetListUsersInBlackList(string userId);
        BlackList AddUserInBlackList(AddUserInBlackListViewModel addInBlackList);
        BlackList FindBlackList(DeleteUserFromBlackListViewModel delete);
        void DeleteFromBlackList(int id);
    }
}