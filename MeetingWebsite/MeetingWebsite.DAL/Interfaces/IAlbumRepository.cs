using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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