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
                return BadRequest(new { message = "User with this email is already registered" });

            return Ok(result);
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

            var user =  await _accountService.GetUser(userId);
            if (user == null)
            {
                return BadRequest("Error");
            }

            var result = await _accountService.ConfirmEmail(user, code);
            if (result.Succeeded)
                return Redirect("http://localhost:4200/user/login");
            return BadRequest(result.Message);
        }

        //POST : /api/account/Login
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var token = await _accountService.LoginUser(model);
            if (token != null)
                return Ok(new { token });
            return BadRequest(new { message = "Username or password is incorrect or not confirm email." });
        }

        //GET : /api/account/SignInWithGoogle
        //[HttpGet, Route("SignInWithGoogle")]
        //public IActionResult SignInWithGoogle()
        //{
        //    var authenticationProperties =
        //        _signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action(nameof(HandleExternalLogin)));
        //    return Challenge(authenticationProperties, "Google");
        //}

        //public async Task<object> HandleExternalLogin()
        //{
        //    var info = await _signInManager.GetExternalLoginInfoAsync();
        //    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

        //    if (result.Succeeded)
        //        return Redirect("http://localhost:4200");

        //    var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //    var newUser = new User
        //    {
        //        UserName = email,
        //        Email = email,
        //        EmailConfirmed = true
        //    };
        //    var createResult = await _userManager.CreateAsync(newUser);
        //    if (!createResult.Succeeded)
        //        throw new Exception(createResult.Errors.Select(e => e.Description).Aggregate((errors, error) => $"{errors}, {error}"));

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim("UserID", newUser.Id)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials =
        //            new SigningCredentials(
        //                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettingsOption.JWT_secret)),
        //                SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //    var token = tokenHandler.WriteToken(securityToken);
        //    await _signInManager.SignInAsync(newUser, isPersistent: false);
        //    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        //    return token;
        //}
    }
}