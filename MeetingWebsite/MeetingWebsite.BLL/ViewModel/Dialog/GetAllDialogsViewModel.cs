using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class GetAllDialogsViewModel
    {
        public string UserId { get; set; }
        public int DialogId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Avatar { get; set; }

        public GetAllDialogsViewModel(string userId, int dialogId, User user)
        {
            UserId = user.Id;
            DialogId = dialogId;
            Firstname = user.FirstName;
            Lastname = user.LastName;

            if (user.Avatar != null)
            {
                Avatar = user.HomeDir + user.Avatar.Path;
            }
            else
            {
                Avatar = "/File/Nophoto.jpg";
            }
        }

        public static IEnumerable<GetAllDialogsViewModel> MapToViewModels(string userId,
            IEnumerable<Models.Entities.Dialog> dialogs)
        {
            return dialogs.Select(dialog => dialog.SenderId == userId
                ? new GetAllDialogsViewModel(userId, dialog.Id, dialog.Receiver)
                : new GetAllDialogsViewModel(userId, dialog.Id, dialog.Sender));
        }
    }
}