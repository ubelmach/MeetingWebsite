using System.Linq;
using System.Threading.Tasks;
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

        //GET: api/friend/Friends
        [HttpGet, Route("Friends")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var friends = await _friendService.FindFriendCurrentUser(userId);
            if (friends == null)
            {
                return BadRequest(new { message = "Error, you have no friends yet" });
            }

           return Ok(ShowFriendViewModel.MapToViewModels(userId, friends).ToList());
        }

        //GET: api/friend/FriendInfo/id
        [HttpGet, Route("FriendInfo/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var friend = await _accountService.GetUser(id);
            var showInfoFriend = new ShowInformationFriendViewModel(friend);
            return Ok(showInfoFriend);
        }

        //POST: api/friend/NewRequest/{id}
        [HttpGet, Route("NewRequest/{userId}")]
        public IActionResult SendRequest(string userId)
        {
            var currentUserId = User.Claims.First(c => c.Type == "UserID").Value;
            var request = new SendFriendRequestViewModel(currentUserId, userId);
            var sendRequest = _friendService.SendRequest(request);
            if (sendRequest == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //GET: api/friend/ListNewRequests
        [HttpGet, Route("ListNewRequests")]
        public IActionResult GetListFriendRequests()
        {
            var currentUserId = User.Claims.First(c => c.Type == "UserID").Value;
            var friendRequests = _friendService.FindNewRequests(currentUserId);
            var showNewRequests = friendRequests.Select(request => new ShowNewRequestsViewModel(request)).ToList();
            return Ok(showNewRequests);
        }

        //GET: api/friend/AcceptNewRequest/id
        [HttpGet, Route("AcceptNewRequest/{id}")]
        public IActionResult AcceptNewRequest(int id)
        {
            _friendService.Accepted(id);
            return Ok();
        }

        //GET: api/friend/RejectNewRequest/id
        [HttpGet, Route("RejectNewRequest/{id}")]
        public IActionResult RejectNewRequest(int id)
        {
            _friendService.Rejected(id);
            return Ok();
        }

        //GET: api/friend/DeleteFriend/id
        [HttpGet, Route("DeleteFriend/{friendshipId}")]
        public IActionResult DeleteFriendship(int friendshipId)
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;

            _friendService.MoveRequest(friendshipId, userId);
            return Ok();
        }
    }
}