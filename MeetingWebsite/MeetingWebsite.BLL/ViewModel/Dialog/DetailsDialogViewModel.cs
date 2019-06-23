using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class DetailsDialogViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Date { get; set; }
        public string Avatar { get; set; }
        public string Text { get; set; }
        public List<string> Photos { get; set; }

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

            var path = new List<string>();
            if (message.Files.Any())
            {
                foreach (var file in message.Files)
                {
                    path.Add(file.Path);
                }

                Photos = path;
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