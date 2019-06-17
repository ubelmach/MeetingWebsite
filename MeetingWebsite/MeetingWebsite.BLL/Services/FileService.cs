using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Hosting;

namespace MeetingWebsite.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _database;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IUnitOfWork uow,
            IHostingEnvironment hostingEnvironment)
        {
            _database = uow;
            _hostingEnvironment = hostingEnvironment;
        }

        public void SetUserFolder(User user)
        {
            var createFolder = _hostingEnvironment.WebRootPath + "/File/" + user.Id;

            user.HomeDir = "/File/" + user.Id;
            _database.UserRepository.Update(user);
            _database.Save();

            if (!Directory.Exists(createFolder))
            {
                Directory.CreateDirectory(createFolder);
            }
        }

        public async Task AddUserAvatar(EditUserAvatarViewModel editAvatar)
        {
            var createFolder = _hostingEnvironment.WebRootPath + editAvatar.User.HomeDir + "/Avatar/";
            var path = "/Avatar/" + editAvatar.Avatar.FileName;

            if (!Directory.Exists(createFolder))
            {
                Directory.CreateDirectory(createFolder);
            }

            using (var fileStream = new FileStream(createFolder + editAvatar.Avatar.FileName, FileMode.Create))
            {
                await editAvatar.Avatar.CopyToAsync(fileStream);
            }

            var avatar = new FileModel
            {
                UserId = editAvatar.User.Id,
                Name = editAvatar.Avatar.FileName,
                Path = path
            };
            _database.FileRepository.Create(avatar);
            _database.Save();

            editAvatar.User.AvatarId = avatar.Id;
            _database.UserRepository.Update(editAvatar.User);
            _database.Save();
        }

        public async Task AddPhotoInAlbum(AddPhotoInAlbumViewModel photos)
        {
            var album =_hostingEnvironment.WebRootPath + photos.HomeDir + photos.AlbumDir + '/';

            foreach (var photo in photos.Photos)
            {
                var path = photos.AlbumDir + photos.AlbumName + photo.FileName;
                using (var fileStream = new FileStream(album + photo.FileName, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var file = new FileModel
                {
                    UserId = photos.UserId,
                    AlbumId = photos.AlbumId,
                    Name = photo.FileName,
                    Path = path
                };
                _database.FileRepository.Create(file);
            }
            _database.Save();
        }

        public FileModel FindPhotoInAlbum(int id)
        {
            return _database.FileRepository.Get(id);
        }

        public void DeletePhotoInAlbum(int id)
        {
            _database.FileRepository.Delete(id);
            _database.Save();
        }

        public IEnumerable<FileModel> FindPhotosInAlbum(int id)
        {
            return _database.FileRepository.Find(x => x.AlbumId == id);
        }
    }
}