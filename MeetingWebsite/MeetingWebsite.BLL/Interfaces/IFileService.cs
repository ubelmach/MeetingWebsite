using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.Services
{
    public interface IFileService
    {
        void SetUserFolder(User user);
        Task AddUserAvatar(EditUserAvatarViewModel editAvatar);
        Task AddPhotoInAlbum(AddPhotoInAlbumViewModel photo);
        Task AddDialogMessagePhotos(int dialogId, int messageId, IFormFileCollection photos);
        FileModel FindPhotoInAlbum(int id);
        void DeletePhotoInAlbum(int id);
        IEnumerable<FileModel> FindPhotosInAlbum(int id);
    }
}