using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly IPurposeService _purposeService;
        private readonly ILanguageService _languageService;
        private readonly IBadHabitsService _badHabitsService;
        private readonly IInterestsService _interestsService;

        private const int LengthMax = 5242880;
        private const string CorrectType = "image/jpeg";

        public UserController(IAccountService accountService,
            IUserService userService,
            IFileService fileService,
            IPurposeService purposeService,
            ILanguageService languageService,
            IBadHabitsService badHabitsService,
            IInterestsService interestsService)
        {
            _accountService = accountService;
            _userService = userService;
            _fileService = fileService;
            _purposeService = purposeService;
            _languageService = languageService;
            _badHabitsService = badHabitsService;
            _interestsService = interestsService;
        }

        //GET: /api/user/UserProfile
        [Authorize]
        [HttpGet, Route("UserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _accountService.GetUser(userId);

            if (user == null)
                return BadRequest();

            var userProfile = new UserProfileViewModel(user);

            return Ok(userProfile);
        }

        //PUT : /api/user/EditUserInformation
        [HttpPut, Route("EditUserInformation")]
        public async Task<IActionResult> EditUserInformation([FromBody] EditUserProfileInformation editUser)
        {
            if (editUser == null)
                return BadRequest();

            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            editUser.Id = userId;

            var result = await _userService.EditUserInformation(editUser);
            if (result == null)
                return BadRequest(new {message = "Error edit user information"});
            return Ok();
        }

        //PUT : /api/user/EditUserAvatar
        [HttpPut, Route("EditUserAvatar")]
        public async Task<IActionResult> EditUserAvatar()
        {
            var editUserAvatar = new EditUserAvatarViewModel();
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _accountService.GetUser(userId);
            var file = HttpContext.Request.Form.Files[0];
            editUserAvatar.User = user;
            editUserAvatar.Avatar = file;

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

            await _fileService.AddUserAvatar(editUserAvatar);
            return Ok(editUserAvatar);
        }
        
        //GET: /api/user/ZodiacSigns
        [HttpGet, Route("ZodiacSigns")]
        public List<string> GetZodiacSigns()
        {
            return Enum.GetNames(typeof(ZodiacSigns)).ToList();
        }

        //GET: /api/user/Genders
        [HttpGet, Route("Genders")]
        public List<string> GetGenders()
        {
            return Enum.GetNames(typeof(Genders)).ToList();
        }

        //GET: /api/user/Purpose
        [HttpGet, Route("Purpose")]
        public IEnumerable<PurposeOfDating> GetPurpose()
        {
            return _purposeService.GetAll().ToList();
        }

        //GET: /api/user/Languages
        [HttpGet, Route("Languages")]
        public IEnumerable<Languages> GetLanguages()
        {
            return _languageService.GetAll().ToList();
        }

        //GET: /api/user/BadHabits
        [HttpGet, Route("BadHabits")]
        public IEnumerable<BadHabits> GetBadHabits()
        {
            return _badHabitsService.GetAll().ToList();
        }

        //GET: /api/user/Interests
        [HttpGet, Route("Interests")]
        public IEnumerable<Interests> GetInterests()
        {
            return _interestsService.GetAll().ToList();
        }
    }
}