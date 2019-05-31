using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IAlbumService
    {
        IEnumerable<PhotoAlbum> FindAllAlbumsCurrentUser(string userId);
        PhotoAlbum OpenAlbum(int id);
        PhotoAlbum CreateAlbum(CreateAlbumViewModel newAlbum);
    }
}