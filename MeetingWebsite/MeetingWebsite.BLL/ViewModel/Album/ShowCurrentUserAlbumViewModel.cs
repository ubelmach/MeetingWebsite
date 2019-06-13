using MeetingWebsite.Models.Entities;
using System.Collections.Generic;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowCurrentUserAlbumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ShowCurrentUserAlbumViewModel(PhotoAlbum album)
        {
            Id = album.Id;
            Name = album.Name;
        }
    }
}