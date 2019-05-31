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
            IHostingEnvironment appEnvironment)
        {
            Database = uow;
            _hostingEnvironment = appEnvironment;
        }

        public void SetUserFolder(User user)
        {
            user.HomeDir = _hostingEnvironment.WebRootPath + "\\File\\" + user.Id;
            var path = this._hostingEnvironment.WebRootPath + "\\File\\" + user.Id;

            Database.UserRepository.Update(user);
            Database.Save();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public Task<User> AddUserAvatar(EditUserAvatarViewModel editAvatar, User user)
        {
            throw new System.NotImplementedException();
        }

        //public Task<User> AddUserAvatar(EditUserAvatarViewModel editAvatar, User user)
        //{
        //    var path =

        //}

        //public async Task<User> AddUserAvatar(EditUserAvatarViewModel editAvatar)
        //{

        //    var path = "/Photos/" + uploadedFile.FileName;
        //    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
        //    {
        //        await uploadedFile.CopyToAsync(fileStream);
        //    }
        //    var file = new FileModel
        //    {
        //        Name = uploadedFile.FileName,
        //        Path = path,
        //        IdProduct = idProduct
        //    };
        //    Database.FileModels.Create(file);
        //    Database.Save();

        //}
    }
}