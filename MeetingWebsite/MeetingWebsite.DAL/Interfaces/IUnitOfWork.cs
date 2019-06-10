using System;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Friendship> FriendRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<UserProfile> UserProfileRepository { get; }
        IRepository<FileModel> FileRepository { get; }
        IRepository<PhotoAlbum> AlbumRepository { get; }
        IRepository<BlackList> BlacklistRepository { get; }
        IRepository<PurposeOfDating> PurposeRepository { get; }
        IRepository<Languages> LanguageRepository { get; }
        void Save();
    }
}