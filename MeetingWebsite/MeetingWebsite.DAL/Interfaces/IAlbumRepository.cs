using System;
using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<PhotoAlbum> Find(Func<PhotoAlbum, bool> predicate);
        PhotoAlbum Get(int id);
        void Create(PhotoAlbum newPhotoAlbum);
        void Delete(int id);
    }
}