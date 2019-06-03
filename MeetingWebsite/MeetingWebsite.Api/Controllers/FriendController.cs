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
        public IFriendService _friendService;
        public IAccountService _accountService;

        public FriendController(IFriendService friendService,
            IAccountService accountService)
        {
            _friendService = friendService;
            _accountService = accountService;
        }

        //GET: api/friend/GetCurrentUserFriend
        [HttpGet, Route("GetCurrentUserFriend")]
        public IActionResult GetAll()
        {
            var userId = GetUserId();
            var friend = _friendService.FindFriendCurrentUser(userId).ToList();

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
            var friend = _accountService.GetUser(id);
            var showInfoFriend = _friendService.ShowInformationFriend(friend);

            return Ok(showInfoFriend);
        }

        //POST: api/friend/SendFriendRequest/{id}
        [HttpPost, Route("SendFriendRequest/{id}")]
        public IActionResult Post(string userId)
        {
            var currentUserId = GetUserId();

            var request = new SendFriendRequestViewModel
            {
                WhoSendsRequest = currentUserId,
                WhoReceivesRequest = userId
            };

            var sendRequest = _friendService.SendRequest(request);
            return Ok();
        }

        //GET: api/friend/GetListFriendRequests
        [HttpGet, Route("GetListFriendRequests")]
        public IActionResult GetListFriendRequests()
        {
            var currentUserId = GetUserId();
            var friendRequests = _friendService.FindNewRequests(currentUserId);

            var showNewRequests = friendRequests.Select(item => new ShowNewRequestsViewModel
            {
                FirstName = item.FirstFriend.FirstName,
                LastName = item.FirstFriend.LastName
            }).ToList();

            return Ok(showNewRequests);
        }

        //PUT: api/friend/AcceptNewRequest/id
        [HttpPut, Route("AcceptNewRequest/{id}")]
        public IActionResult AcceptNewRequest(int id)
        {
            _friendService.Accepted(id);
            return Ok();
        }

        //PUT: api/friend/RejectNewRequest/id
        [HttpPut, Route("RejectNewRequest/{id}")]
        public IActionResult RejectNewRequest(int id)
        {
            _friendService.Rejected(id);
            return Ok();
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }

    }
}