using System;

namespace MeetingWebsite.BLL.ViewModel
{
    public class AddUserInBlackListViewModel
    {
        public string CurrentUserId { get; set; }
        public string WhomId { get; set; }
        public DateTime Date { get; set; }
        public AddUserInBlackListViewModel(string currentUserId, string blockedUserId)
        {
            CurrentUserId = currentUserId;
            WhomId = blockedUserId;
            Date = DateTime.Now;
        }
    }
}