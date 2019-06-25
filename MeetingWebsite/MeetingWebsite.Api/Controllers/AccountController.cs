using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private const string LoginUrl = "http://localhost:4200/user/login";
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //POST: /api/account/Register
        [HttpPost, Route("Register")]
        public async Task<object> Register([FromBody] RegisterViewModel model)
        {
            var url = HttpContext.Request.Host.ToString();
            var result = await _accountService.RegisterUser(model, url);
            if (result == null)
            {
                return BadRequest(new { message = "User with this email is already registered" });
            }
            return Ok(result);
        }

        //POST: /api/account/ForgotPassword
        [HttpPost, Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordViewModel model)
        {
            var url = HttpContext.Request.Host.ToString();
            var result = await _accountService.UserForgotPassword(model, url);
            if (result == null)
            {
                return BadRequest(new { message = "Not founded user with this email" });
            }

            return Ok();
        }

        //GET: /api/account/ConfirmEmail?userid=value&code=value
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            var user = await _accountService.GetUser(userId);
            if (user == null)
            {
                return BadRequest("Error");
            }

            var result = await _accountService.ConfirmEmail(user, code);
            if (result.Succeeded)
            {
                return Redirect(LoginUrl);
            }
            return BadRequest(result.Message);
        }

        //POST: /api/account/Reset
        [HttpPost, Route("Reset")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model)
        {
            var result = await _accountService.ResetPassword(model);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }


        //POST: api/account/Change
        [HttpPost, Route("Change")]
        public async Task<IActionResult> Change([FromForm] ChangePasswordViewModel model)
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var result = await _accountService.ChangePassword(model, userId);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        //POST : /api/account/Login
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var token = await _accountService.LoginUser(model);
            if (token != null)
            {
                return Ok(new { token });
            }
            return BadRequest(new { message = "Username or password is incorrect or not confirm email." });
        }
    }
}