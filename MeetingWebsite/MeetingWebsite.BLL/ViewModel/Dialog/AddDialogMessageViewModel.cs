using System;
using System.Collections.Generic;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class AddDialogMessageViewModel
    {
        public string SenderId { get; set; }
        public int DialogId { get; set; }
        public string Text { get; set; }
        public bool New { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}