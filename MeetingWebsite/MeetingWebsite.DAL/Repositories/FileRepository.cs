using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly MeetingDbContext _db;

        public FileRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(FileModel item)
        {
            _db.Files.Add(item);
        }

        public IEnumerable<FileModel> Find(Func<FileModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}