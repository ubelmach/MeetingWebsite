using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class AlbumRepository : IRepository<PhotoAlbum>
    {
        private MeetingDbContext _db;

        public AlbumRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<PhotoAlbum> Find(Func<PhotoAlbum, bool> predicate)
        {
            return _db.PhotoAlbums.Where(predicate);
        }

        public PhotoAlbum Get(int id)
        {
            return _db.PhotoAlbums.Find(id);
        }

        public void Create(PhotoAlbum newPhotoAlbum)
        {
            _db.PhotoAlbums.AddRange(newPhotoAlbum);
        }

        public void Delete(int id)
        {
            var album = _db.PhotoAlbums.Find(id);
            if (album != null)
                _db.PhotoAlbums.Remove(album);
        }

        public IEnumerable<PhotoAlbum> GetAll()
        {
            return _db.PhotoAlbums;
        }

        public void Update(PhotoAlbum item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}