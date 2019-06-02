using System.Collections.Generic;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel
{
    public class AddPhotoInAlbumViewModel
    {
        public string UserId { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string HomeDir { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}