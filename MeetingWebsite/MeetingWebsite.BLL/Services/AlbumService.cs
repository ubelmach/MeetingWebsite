using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private IUnitOfWork _database { get; set; }

        public AlbumService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<PhotoAlbum> FindAllAlbumsCurrentUser(string userId)
        {
            return _database.AlbumRepository.Find(x => x.UserId == userId);
        }

        public PhotoAlbum OpenAlbum(int id)
        {
            return _database.AlbumRepository.Get(id);
        }

        public PhotoAlbum CreateAlbum(CreateAlbumViewModel createAlbum)
        {
            try
            {
                var newAlbum = new PhotoAlbum
                {
                    Name = createAlbum.Name,
                    UserId = createAlbum.UserId
                };

                _database.AlbumRepository.Create(newAlbum);
                _database.Save();
                return newAlbum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}