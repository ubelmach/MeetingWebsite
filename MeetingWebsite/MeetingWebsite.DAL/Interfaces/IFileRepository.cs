using System;
using System.Collections.Generic;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IFileRepository<TFileModel>
    {
        void Create(TFileModel item);
        IEnumerable<TFileModel> Find(Func<TFileModel, bool> predicate);
    }
}