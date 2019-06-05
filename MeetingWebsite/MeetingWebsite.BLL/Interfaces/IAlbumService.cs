using System.Collections.Generic;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IAlbumService
    {
        IEnumerable<PhotoAlbum> FindAllAlbumsCurrentUser(string userId);
        PhotoAlbum FindAlbum(int id);
        PhotoAlbum OpenAlbum(int id);
        PhotoAlbum CreateAlbum(CreateAlbumViewModel newAlbum);
        void DeleteAlbum(int id);
    }
}