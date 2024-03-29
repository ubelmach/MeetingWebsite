﻿using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel
{
    public class EditUserAvatarViewModel
    {
        public User User { get; set; }
        public IFormFile Avatar { get; set; }
        public EditUserAvatarViewModel(User user, IFormFile file)
        {
            User = user;
            Avatar = file;
        }
    }
}