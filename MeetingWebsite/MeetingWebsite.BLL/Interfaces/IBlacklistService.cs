using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IBlacklistService
    {
        Task<List<BlackList>> GetListUsersInBlackList(string userId);
        Task<BlackList> AddUserInBlackList(AddUserInBlackListViewModel addInBlackList);
        Task<bool> CheckBlackList(string userId, string who);
        Task<bool> Check(string userId, string who);
        void DeleteFromBlackList(int id);
    }
}