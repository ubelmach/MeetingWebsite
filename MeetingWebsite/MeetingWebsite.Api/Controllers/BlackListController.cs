using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            var userId = GetUserId();
            var blackList = await _blacklistService.GetListUsersInBlackList(userId);
            if (blackList != null)
            {
                return Ok(ShowBlackListCurrentUserViewModel.MapToViewModels(blackList).ToList());
            }

            return Ok();
        }

        //GET: api/blacklist/AddUserInBlackList/userId
        [HttpGet, Route("AddUserInBlackList/{userId}")]
        public async Task<IActionResult> Add(string userId)
        {
            var currentUserId = User.Claims.First(c => c.Type == "UserID").Value;
            var addInBlackList = await _blacklistService.AddUserInBlackList(new AddUserInBlackListViewModel(currentUserId, userId));
            if (addInBlackList == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        //GET : api/blacklist/DeleteUserFromBlackList/{id}
        [HttpGet, Route("DeleteUserFromBlackList/{id}")]
        public IActionResult Delete(int id)
        {
            _blacklistService.DeleteFromBlackList(id);
            return Ok();
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }
    }
}