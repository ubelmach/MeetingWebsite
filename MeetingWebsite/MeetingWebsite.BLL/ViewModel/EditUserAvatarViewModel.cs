using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel
{
    public class EditUserAvatarViewModel
    {
        public IFormFile Avatar { get; set; }
    }
}