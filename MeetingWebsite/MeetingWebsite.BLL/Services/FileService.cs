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
        private IUnitOfWork Database { get; set; }

        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IUnitOfWork uow,
            IHostingEnvironment hostingEnvironment)
        {
            Database = uow;
            _hostingEnvironment = hostingEnvironment;
        }

        public void SetUserFolder(User user)
        {
            var createFolder = _hostingEnvironment.WebRootPath + "/File/" + user.Id;

            user.HomeDir = "/File/" + user.Id;
            Database.UserRepository.Update(user);
            Database.Save();

            if (!Directory.Exists(createFolder))
                Directory.CreateDirectory(createFolder);
        }

        public async Task AddUserAvatar(EditUserAvatarViewModel editAvatar)
        {
            var createFolder = _hostingEnvironment.WebRootPath + editAvatar.User.HomeDir + "/Avatar/";
            var path = "/Avatar/" + editAvatar.Avatar.FileName;

            if (!Directory.Exists(createFolder))
                Directory.CreateDirectory(createFolder);

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
            Database.FileRepository.Create(avatar);
            Database.Save();

            editAvatar.User.AvatarId = avatar.Id;
            Database.UserRepository.Update(editAvatar.User);
            Database.Save();
        }

        public async Task AddPhotoInAlbum(AddPhotoInAlbumViewModel photos)
        {
            var album =_hostingEnvironment.WebRootPath + photos.HomeDir + photos.AlbumDir + '/';

            foreach (var photo in photos.Photos)
            {
                var path = photos.AlbumDir + photo.FileName;
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
                Database.FileRepository.Create(file);
            }
            Database.Save();
        }

        public FileModel FindPhotoInAlbum(int id)
        {
            return Database.FileRepository.Get(id);
        }

        public void DeletePhotoInAlbum(int id)
        {
            Database.FileRepository.Delete(id);
            Database.Save();
        }
    }
}