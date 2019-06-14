using System;
using System.Linq;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlackListController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        //GET: api/blacklist/BlackList
        [HttpGet, Route("BlackList")]
        public IActionResult Get()
        {
            var userId = GetUserId();
            var blackList = _blacklistService.GetListUsersInBlackList(userId);

            var showBlackList = blackList.Select(item => new ShowBlackListCurrentUserViewModel(item)).ToList();

            return Ok(showBlackList);
        }

        //GET: api/blacklist/AddUserInBlackList/userId
        [HttpGet, Route("AddUserInBlackList/{userId}")]
        public IActionResult Add(string userId)
        {
            var currentUserId = GetUserId();

            var add = new AddUserInBlackListViewModel(currentUserId, userId);
            var addInBlackList = _blacklistService.AddUserInBlackList(add);
            if (addInBlackList == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //DELETE : api/blacklist/DeleteUserFromBlackList/{userId}
        [HttpDelete, Route("DeleteUserFromBlackList/{userId}")]
        public IActionResult Delete([FromForm] string userId)
        {
            var currentUserId = GetUserId();

            var delete = new DeleteUserFromBlackListViewModel(currentUserId, userId);

            var findBlackList = _blacklistService.FindBlackList(delete);
            if (findBlackList == null)
            {
                return NotFound();
            }
            _blacklistService.DeleteFromBlackList(findBlackList.Id);
            return Ok();
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }
    }
}