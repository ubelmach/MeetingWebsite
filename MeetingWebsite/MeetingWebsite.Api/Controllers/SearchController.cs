using System.Linq;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        //GET: /api/search/SearchUsersByCriteria
        [HttpGet, Route("SearchUsersByCriteria")]
        public IActionResult Get(SearchByCriteriaViewModel criteria)
        {
            var search = _searchService.FindUsers(criteria);

            var resultSearch = search.Select(item => new ResultSearchByCriteriaViewModel
            {
                UserId = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Birthday.Ticks,
                Avatar = item.Avatar.Path
            });

            return Ok(resultSearch);
        }
    }
}