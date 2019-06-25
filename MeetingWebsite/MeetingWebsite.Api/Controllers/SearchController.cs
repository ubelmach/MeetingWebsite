using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.Api.Hub;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        //POST: /api/search/SearchUsersByCriteria
        [HttpPost, Route("SearchUsersByCriteria")]
        public IEnumerable<ResultSearchByCriteriaViewModel> Get(SearchByCriteriaViewModel criteria)
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            criteria.CurrentUserId = userId;
            var search = _searchService.FindUsers(criteria).ToList();
            var searchResult = search.Select(item => new ResultSearchByCriteriaViewModel(item)).ToList();
            var userConnectionList = ChatHub._usersList;

            foreach (var user in searchResult)
            {
                user.Online = userConnectionList.Any(x => x.UserId == user.UserId);
            }

            return searchResult;
        }
    }
}