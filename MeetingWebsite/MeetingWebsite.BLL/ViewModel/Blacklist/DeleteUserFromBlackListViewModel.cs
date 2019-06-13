namespace MeetingWebsite.BLL.ViewModel
{
    public class DeleteUserFromBlackListViewModel
    {
        public string CurrentUserId { get; set; }
        public string WhomId { get; set; }
        public DeleteUserFromBlackListViewModel(string currentUserId, string blockedUserId)
        {
            CurrentUserId = currentUserId;
            WhomId = blockedUserId;
        }
    }
}