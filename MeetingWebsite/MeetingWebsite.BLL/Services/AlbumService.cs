using System;
using System.Collections.Generic;
using System.IO;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Hosting;

namespace MeetingWebsite.BLL.Services
{
    public class AlbumService : IAlbumService
    {
        private IUnitOfWork _database { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public AlbumService(IUnitOfWork database,
            IHostingEnvironment hostingEnvironment)
        {
            _database = database;
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<PhotoAlbum> FindAllAlbumsCurrentUser(string userId)
        {
            return _database.AlbumRepository.Find(x => x.UserId == userId);
        }

        public PhotoAlbum FindAlbum(int id)
        {
            return _database.AlbumRepository.Get(id);
        }

        public PhotoAlbum OpenAlbum(int id)
        {
            return _database.AlbumRepository.Get(id);
        }

        public PhotoAlbum CreateAlbum(CreateAlbumViewModel createAlbum)
        {
            try
            {
                var createFolder = _hostingEnvironment.WebRootPath + createAlbum.HomeDir + "/Albums/" + createAlbum.Name;
                var path = "/Albums/" + createAlbum.Name;

                if (!Directory.Exists(createFolder))
                    Directory.CreateDirectory(createFolder);

                var newAlbum = new PhotoAlbum
                {
                    Name = createAlbum.Name,
                    UserId = createAlbum.UserId,
                    Path = path
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

        public void DeleteAlbum(int id)
        {
            _database.AlbumRepository.Delete(id);
            _database.Save();
        }
    }
}