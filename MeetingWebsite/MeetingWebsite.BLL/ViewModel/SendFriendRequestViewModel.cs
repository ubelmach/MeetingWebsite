using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.BLL.ViewModel
{
    public class SendFriendRequestViewModel
    {
        public string WhoSendsRequest { get; set; }
        public string WhoReceivesRequest { get; set; }
        public InviteStatuses InviteStatuses { get; set; }
    }
}