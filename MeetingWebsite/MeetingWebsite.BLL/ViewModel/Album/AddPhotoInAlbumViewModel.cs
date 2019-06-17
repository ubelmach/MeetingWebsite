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
        public string AlbumDir { get; set; }
        public IFormFileCollection Photos { get; set; }

        public void AppendAdditionalInfo(PhotoAlbum album, User user, IFormFileCollection files)
        {
            AlbumId = album.Id;
            AlbumName = album.Name;
            HomeDir = user.HomeDir;
            AlbumDir = album.Path;
            UserId = user.Id;
            Photos = files;
        }
    }
}