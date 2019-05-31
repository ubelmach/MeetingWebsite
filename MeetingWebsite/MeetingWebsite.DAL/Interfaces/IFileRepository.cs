using System;
using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IFileRepository
    {
        void Create(FileModel item);
        IEnumerable<FileModel> Find(Func<FileModel, bool> predicate);
    }
}