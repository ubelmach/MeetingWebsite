using System.IO;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Org.BouncyCastle.Bcpg.OpenPgp;

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
            user.HomeDir = _hostingEnvironment.WebRootPath + "\\File\\" + user.Id;
           // var path = this._hostingEnvironment.WebRootPath + "\\File\\" + user.Id;

            Database.UserRepository.Update(user);
            Database.Save();

            if (!Directory.Exists(user.HomeDir))
                Directory.CreateDirectory(user.HomeDir);
        }

        public async Task AddUserAvatar(EditUserAvatarViewModel editAvatar)
        {
            var path = editAvatar.User.HomeDir + "\\Avatar\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (var fileStream = new FileStream(path + editAvatar.Avatar.FileName, FileMode.Create))
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

            //editAvatar.User.AvatarId = avatar.Id;
            Database.UserRepository.Update(editAvatar.User);
            Database.Save();
        }

        public async Task AddPhotoInAlbum(AddPhotoInAlbumViewModel photos)
        {
            var path = photos.HomeDir + "\\Albums\\" + photos.AlbumName;

            foreach (var photo in photos.Photos)
            {
                using (var fileStream = new FileStream(path + photo.FileName, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                var file = new FileModel
                {
                    UserId = photos.UserId,
                    Name = photo.FileName,
                    Path = path,
                    AlbumId = photos.AlbumId
                };
                Database.FileRepository.Create(file);
                Database.Save();
            }
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