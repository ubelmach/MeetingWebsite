using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel
{
    public class EditUserAvatarViewModel
    {
        //public string Id { get; set; }
        //public string HomeDir { get; set; }
        public User User { get; set; }
        public IFormFile Avatar { get; set; }
    }
}