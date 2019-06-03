using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
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

        private const int LengthMax = 5242880;
        private const string CorrectType = "image/jpeg";

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

            Mapper.Initialize(cfg => cfg.CreateMap<User, UserProfileViewModel>());
            var userProfile = Mapper.Map<User, UserProfileViewModel>(await _accountService.GetUser(userId));

            if (userProfile == null)
                return NotFound();
            return Ok(userProfile);
        }

        //PUT : /api/user/EditUserInformation
        [HttpPut, Route("EditUserInformation")]
        public object EditUserInformation([FromForm] EditUserProfileInformation editUser)
        {
            if (editUser == null)
                return BadRequest();

            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            editUser.Id = userId;

            _userService.EditUserInformation(editUser);
            return Ok(editUser);
        }

        //PUT : /api/user/EditUserAvatar
        [HttpPut, Route("EditUserAvatar")]
        public async Task<object> EditUserAvatar([FromForm] EditUserAvatarViewModel editUserAvatar)
        {
            if (editUserAvatar == null)
                return BadRequest();

            var type = editUserAvatar.Avatar.ContentType;
            var length = editUserAvatar.Avatar.Length;

            if (type != CorrectType)
            {
                ModelState.AddModelError("Avatar", "Error, allowed image resolution jpg / jpeg");
                return BadRequest(ModelState);
            }

            if (length > LengthMax)
            {
                ModelState.AddModelError("Avatar", "Error, permissible image size should not exceed 2 MB");
                return BadRequest(ModelState);
            }

            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = _accountService.GetUser(userId);
            editUserAvatar.User = user.Result;

            await _fileService.AddUserAvatar(editUserAvatar);
            return Ok(editUserAvatar);
        }
    }
}