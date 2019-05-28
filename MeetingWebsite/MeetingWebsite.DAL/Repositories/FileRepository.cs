using System;
using System.Collections.Generic;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Repositories
{
    public class FileRepository : IFileRepository<File>
    {
        private readonly MeetingDbContext _db;

        public FileRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(File item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> Find(Func<File, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}