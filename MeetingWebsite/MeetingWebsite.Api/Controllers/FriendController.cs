using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
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
            var friends = _friendService.FindFriendCurrentUser(userId).ToList();

            if (!friends.Any())
                return BadRequest(new { message = "Error, you have no friends yet" });

            var showFriendCurrentUser = new List<ShowFriendCurrentUserViewModel>();

            foreach (var friend in friends)
            {
                if (friend.FirstFriendId == userId)
                {
                    showFriendCurrentUser.Add(new ShowFriendCurrentUserViewModel
                    {
                        FirstName = friend.SecondFriend.FirstName,
                        LastName = friend.SecondFriend.LastName
                    });
                }

                else
                {
                    showFriendCurrentUser.Add(new ShowFriendCurrentUserViewModel
                    {
                        FirstName = friend.FirstFriend.FirstName,
                        LastName = friend.FirstFriend.LastName
                    });
                }
            }
            
            return Ok(showFriendCurrentUser);
        }

        //GET: api/friend/DetailsFriendInformation/id
        [HttpGet, Route("DetailsFriendInformation/{id}")]
        public IActionResult Get(string id)
        {
            var friend = _accountService.GetUser(id);

            var showInfoFriend = new ShowInformationFriendViewModel(friend.Result);

            return Ok(showInfoFriend);
        }

        //POST: api/friend/SendFriendRequest/{id}
        [HttpPost, Route("SendFriendRequest/{userId}")]
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
                Id = item.Id,
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

        //PUT: api/friend/DeleteFriendship/id
        [HttpPut, Route("DeleteFriendship/{id}")]
        public IActionResult DeleteFriendship(int id)
        {
            return Ok();
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }
    }
}