using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel
{
    public class EditUserAvatarViewModel
    {
<<<<<<< HEAD
=======
        //public string Id { get; set; }
        //public string HomeDir { get; set; }
>>>>>>> jwt
        public User User { get; set; }
        public IFormFile Avatar { get; set; }
    }
}