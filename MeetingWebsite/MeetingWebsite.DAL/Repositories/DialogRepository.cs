using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    class DialogRepository : IRepository<Dialog>
    {
        private readonly MeetingDbContext _db;
        public DialogRepository(MeetingDbContext context)
        {
            _db = context;
        }

        public void Create(Dialog item)
        {
            _db.Dialogs.Add(item);
        }

        public void Delete(int id)
        {
            var dialog = _db.Dialogs.Find(id);
            if (dialog != null)
                _db.Dialogs.Remove(dialog);
        }

        public IEnumerable<Dialog> Find(Func<Dialog, bool> predicate)
        {
            return _db.Dialogs.Where(predicate);
        }

        public Dialog Get(int id)
        {
            return _db.Dialogs.Find(id);
        }

        public IEnumerable<Dialog> GetAll()
        {
            return _db.Dialogs;
        }

        public void Update(Dialog item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
