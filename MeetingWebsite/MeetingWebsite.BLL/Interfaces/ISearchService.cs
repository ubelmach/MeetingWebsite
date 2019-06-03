using System.Collections.Generic;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface ISearchService
    {
        IEnumerable<User> FindUsers(SearchByCriteriaViewModel criteria);
    }
}