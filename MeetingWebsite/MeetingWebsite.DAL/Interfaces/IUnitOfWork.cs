using System;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Friendship> FriendRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<PhotoAlbum> PhotoAlbumRepository { get; }
        IUserRepository<User> UserRepository { get; }
        IFileRepository<FileModel> FileRepository { get; }
        void Save();
    }
}