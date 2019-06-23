using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class AddDialogMessageViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Date { get; set; }
        public string Avatar { get; set; }
        public string Text { get; set; }
        public List<string> Photos { get; set; }

        public AddDialogMessageViewModel(Message message)
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
    }
}