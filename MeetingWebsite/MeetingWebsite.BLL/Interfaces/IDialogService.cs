using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel.Dialog;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.Services
{
    public interface IDialogService
    {
        Task<IEnumerable<Dialog>> FindAllDialogs(string userId);
        Dialog FindDialog(int id);
        Task<bool> IsExistDialog(string userId, string receiverId);
        Dialog CreateDialog(string receiverId, string senderId);
        Task<Message> AddDialogMessage(string userId, string message, int dialogId, IFormFileCollection file);
        Task<Dialog> GetDialogDetails(string userId, string companionId);
    }
}