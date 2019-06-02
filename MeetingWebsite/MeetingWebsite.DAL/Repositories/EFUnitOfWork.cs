using System;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly MeetingDbContext _db;
        private FileRepository _fileRepository;
        private FriendshipRepository _friendshipRepository;
        private MessageRepository _messageRepository;
        private AlbumRepository _albumRepository;
        private UserRepository _userRepository;
        private BlacklistRepository _blacklistRepository;

        public EfUnitOfWork(DbContextOptions options)
        {
            _db = new MeetingDbContext(options);
        }

        public IFileRepository FileRepository => 
            _fileRepository ?? (_fileRepository = new FileRepository(_db));

        public IUserRepository<User> UserRepository =>
            _userRepository ?? (_userRepository = new UserRepository(_db));

        public IRepository<Friendship> FriendRepository =>
            _friendshipRepository ?? (_friendshipRepository = new FriendshipRepository(_db));

        public IRepository<Message> MessageRepository =>
            _messageRepository ?? (_messageRepository = new MessageRepository(_db));

        public IAlbumRepository AlbumRepository =>
            _albumRepository ?? (_albumRepository = new AlbumRepository(_db));

        public IBlacklistRepository BlacklistRepository =>
            _blacklistRepository ?? (_blacklistRepository = new BlacklistRepository(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}