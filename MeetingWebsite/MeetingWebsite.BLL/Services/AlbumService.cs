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
        private IUnitOfWork Database { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public AlbumService(IUnitOfWork database,
            IHostingEnvironment hostingEnvironment)
        {
            Database = database;
            _hostingEnvironment = hostingEnvironment;
        }

        public IEnumerable<PhotoAlbum> FindAllAlbumsCurrentUser(string userId)
        {
            return Database.AlbumRepository.Find(x => x.UserId == userId);
        }

        public PhotoAlbum FindAlbum(int id)
        {
            return Database.AlbumRepository.Get(id);
        }

        public PhotoAlbum OpenAlbum(int id)
        {
            return Database.AlbumRepository.Get(id);
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

                Database.AlbumRepository.Create(newAlbum);
                Database.Save();
                return newAlbum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAlbum(int id)
        {
            Database.AlbumRepository.Delete(id);
            Database.Save();
        }
    }
}