using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const int UploadFileMaxLength = 5 * 1024 * 1024;
        private const string CorrectType = "image/jpeg";

        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly IGenderService _genderService;
        public UserController(IAccountService accountService,
            IUserService userService,
            IFileService fileService,
            IGenderService genderService)
        {
            _accountService = accountService;
            _userService = userService;
            _fileService = fileService;
            _genderService = genderService;
        }

        //GET: /api/user/UserProfile
        [Authorize]
        [HttpGet, Route("UserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _accountService.GetUser(userId);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new UserProfileViewModel(user));
        }

        //PUT : /api/user/EditUserInformation
        [HttpPut, Route("EditUserInformation")]
        public async Task<IActionResult> EditUserInformation([FromBody] EditUserProfileInformation editUser)
        {
            if (editUser == null)
            {
                return BadRequest();
            }
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            editUser.Id = userId;

            var result = await _userService.EditUserInformation(editUser);
            if (result == null)
            {
                return BadRequest(new { message = "Error edit user information" });
            }
            return Ok();
        }

        //PUT : /api/user/EditUserAvatar
        [HttpPut, Route("EditUserAvatar")]
        public async Task<IActionResult> EditUserAvatar()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _accountService.GetUser(userId);
            var file = HttpContext.Request.Form.Files[0];
            var editUserAvatar = new EditUserAvatarViewModel(user, file);

            if (editUserAvatar.Avatar.ContentType != CorrectType)
            {
                ModelState.AddModelError("Avatar", "Error, allowed image resolution jpg / jpeg");
                return BadRequest(ModelState);
            }

            if (editUserAvatar.Avatar.Length > UploadFileMaxLength)
            {
                ModelState.AddModelError("Avatar", "Error, permissible image size should not exceed 2 MB");
                return BadRequest(ModelState);
            }

            await _fileService.AddUserAvatar(editUserAvatar);
            return Ok(editUserAvatar);
        }

        //GET: /api/user/Genders
        [HttpGet, Route("Genders")]
        public IEnumerable<Gender> GetGenders()
        {
            return _genderService.GetAll().ToList();
        }
    }
}