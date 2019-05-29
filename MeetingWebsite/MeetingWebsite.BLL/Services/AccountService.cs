using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MeetingWebsite.BLL.Infrastructure;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MeetingWebsite.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork Database { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ApplicationSettings _applicationSettingsOption;
        private readonly IEmailService _emailService;

        public AccountService(IUnitOfWork uow,
            UserManager<User> userManager,
            IOptions<ApplicationSettings> applicationSettingsOption,
            IEmailService emailService)
        {
            Database = uow;
            _userManager = userManager;
            _applicationSettingsOption = applicationSettingsOption.Value;  
            _emailService = emailService;
        }

        public async Task<object> RegisterUser(RegisterViewModel model, string url)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return null;

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encode = HttpUtility.UrlEncode(code);
            var callbackUrl = new StringBuilder("https://")
                .AppendFormat(url)
                .AppendFormat("/api/account/ConfirmEmail")
                .AppendFormat($"?userId={user.Id}&code={encode}");

            await _emailService.SendEmailAsync(user.Email, "Confirm your account",
                $"Confirm the registration by clicking on the link: <a href='{callbackUrl}'>link</a>");
            return result;
        }

        public async Task<OperationDetails> ConfirmEmail(User user, string code)
        {
            var success = await _userManager.ConfirmEmailAsync(user, code);
            return success.Succeeded
                ? new OperationDetails(true, "Success", "")
                : new OperationDetails(false, "Error", "");
        }

        public async Task<object> LoginUser(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null
                && await _userManager.CheckPasswordAsync(user, model.Password)
                && await _userManager.IsEmailConfirmedAsync(user))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials =
                        new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettingsOption.JWT_secret)),
                            SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            else
                return null;
        }

        public async Task<User> GetUser(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}