using System;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Friendship> FriendRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IUserRepository<User> UserRepository { get; }
        IFileRepository FileRepository { get; }
        IAlbumRepository AlbumRepository { get; }
        IBlacklistRepository BlacklistRepository { get; }
        void Save();
    }
}