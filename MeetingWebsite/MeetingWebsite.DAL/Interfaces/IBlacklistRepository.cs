using System;
using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IBlacklistRepository
    {
        IEnumerable<BlackList> Find(Func<BlackList, bool> predicate);
        void Create(BlackList newBlackList);
        void Delete(int id);
    }
}