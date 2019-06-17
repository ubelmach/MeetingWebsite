using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class FileRepository : IRepository<FileModel>
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
            return _db.Files.Where(predicate);
        }

        public FileModel Get(int id)
        {
            return _db.Files.Find(id);
        }

        public void Delete(int id)
        {
            var photo = _db.Files.Find(id);
            if (photo != null)
                _db.Files.Remove(photo);
        }

        public IEnumerable<FileModel> GetAll()
        {
            return _db.Files;
        }

        public void Update(FileModel item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}