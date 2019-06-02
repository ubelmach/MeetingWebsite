using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        public IFriendService _FriendService;
        public IAccountService _AccountService;

        public FriendController(IFriendService friendService)
        {
            _FriendService = friendService;
        }

        //GET: api/friend/GetCurrentUserFriend
        [HttpGet, Route("GetCurrentUserFriend")]
        public IActionResult GetAll()
        {
            var userId = GetUserId();
            var friend = _FriendService.FindFriendCurrentUser(userId).ToList();

            if (friend.GetEnumerator().Current.FirstFriendId == userId)
            {
                var showFriendCurrentUser = friend.Select(item => new ShowFriendCurrentUserViewModel
                {
                    FirstName = item.SecondFriend.FirstName,
                    LastName = item.SecondFriend.LastName
                }).ToList();
                return Ok(showFriendCurrentUser);
            }
            else
            {
                var showFriendCurrentUser = friend.Select(item => new ShowFriendCurrentUserViewModel
                {
                    FirstName = item.FirstFriend.FirstName,
                    LastName = item.FirstFriend.LastName
                }).ToList();
                return Ok(showFriendCurrentUser);
            }
        }

        //GET: api/friend/DetailsFriendInformation/id
        [HttpGet, Route("DetailsFriendInformation/{id}")]
        public IActionResult Get([FromForm] string id)
        {
            var friend = _AccountService.GetUser(id);
            var showInfoFriend = _FriendService.ShowInformationFriend(friend);

            return Ok(showInfoFriend);
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }

    }
}