using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class PhotoAlbumRepository : IRepository<PhotoAlbum>
    {
        private readonly MeetingDbContext _db;

        public PhotoAlbumRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public IEnumerable<PhotoAlbum> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhotoAlbum Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhotoAlbum> Find(Func<PhotoAlbum, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(PhotoAlbum item)
        {
            throw new NotImplementedException();
        }

        public void Update(PhotoAlbum item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}