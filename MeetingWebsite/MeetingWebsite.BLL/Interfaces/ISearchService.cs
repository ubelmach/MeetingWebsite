using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface ISearchService
    {
        IQueryable<User> FindUsers(SearchByCriteriaViewModel criteria);
    }
}