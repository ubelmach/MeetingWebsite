using System;
using System.Collections.Generic;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class AddDialogMessageViewModel
    {
        public int DialogId { get; set; }
        public string SenderId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Date { get; set; }
        public string Avatar { get; set; }
        public string Text { get; set; }

        public AddDialogMessageViewModel(Message message)
        {
            DialogId = message.Id;
            SenderId = message.SenderId;
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
    }
}