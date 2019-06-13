using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.BLL.ViewModel
{
    public class SendFriendRequestViewModel
    {
        public string WhoSendsRequest { get; set; }
        public string WhoReceivesRequest { get; set; }
        public InviteStatuses InviteStatuses { get; set; }
        public SendFriendRequestViewModel(string currentUserId, string userId)
        {
            WhoSendsRequest = currentUserId;
            WhoReceivesRequest = userId;
        }
    }
}