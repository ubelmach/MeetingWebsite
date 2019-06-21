using System;
using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class DetailsDialogViewModel
    {
        public int DialogId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Date { get; set; }
        public string Avatar { get; set; }
        public string Text { get; set; }

        public DetailsDialogViewModel(Message message)
        {
            Firstname = message.Sender.FirstName;
            Lastname = message.Sender.LastName;
            Date = message.Date;
            Text = message.Text;

            if (message.Sender.Avatar != null)
            {
                Avatar = message.Sender.HomeDir + message.Sender.Avatar.Path;
            }
            else
            {
                Avatar = "/File/Nophoto.jpg";
            }

        }

        public static IEnumerable<DetailsDialogViewModel> MapToViewModel(List<Message> messages, string userId)
        {
            foreach (var message in messages)
            {
                yield return new DetailsDialogViewModel(message);
            }

        }
    }
}