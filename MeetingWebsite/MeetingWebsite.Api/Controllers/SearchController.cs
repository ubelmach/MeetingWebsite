﻿using System.Collections.Generic;
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

        //POST: /api/search/SearchUsersByCriteria
        [HttpPost, Route("SearchUsersByCriteria")]
        public IActionResult Get(SearchByCriteriaViewModel criteria)
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            criteria.CurrentUserId = userId;

            var search = _searchService.FindUsers(criteria);

            var resultSearch = new List<ResultSearchByCriteriaViewModel>();
            foreach (var item in search)
            {
                resultSearch.Add(new ResultSearchByCriteriaViewModel(item));
            }

            return Ok(resultSearch);
        }
    }
}