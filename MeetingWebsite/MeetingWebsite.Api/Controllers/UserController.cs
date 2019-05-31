using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public UserController(IAccountService accountService,
            IUserService userService,
            IFileService fileService)
        {
            _accountService = accountService;
            _userService = userService;
            _fileService = fileService;
        }

        //GET: /api/user/UserProfile
        [Authorize]
        [HttpGet, Route("UserProfile")]
        public async Task<object> GetUserProfile()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _accountService.GetUser(userId);

            if (user == null)
                return NotFound();

            var userProfile = new UserProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return Ok(userProfile);
        }

        //PUT : /api/user/EditUserInformation
        [HttpPut, Route("EditUserInformation")]
        public async Task<object> EditUserInformation([FromForm] EditUserProfileInformation editUser)
        {
            if (editUser == null)
                return BadRequest();

            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            editUser.Id = userId;

            await _userService.EditUserInformation(editUser);
            return Ok(editUser);
        }

        //PUT : /api/user/EditUserAvatar
        [HttpPut, Route("EditUserAvatar")]
        public async Task<object> EditUserAvatar([FromForm] EditUserAvatarViewModel editUserAvatar)
        {
            if (editUserAvatar == null)
                return BadRequest();

            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = _accountService.GetUser(userId);

            await _fileService.AddUserAvatar(editUserAvatar, user.Result);
            return Ok(editUserAvatar);
        }
    }
}