using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MeetingWebsite.BLL.Builders;
using MeetingWebsite.BLL.Infrastructure;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace MeetingWebsite.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork Database { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ApplicationSettings _applicationSettingsOption;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly IUserProfileService _userProfileService;
        private const string ConfirmEmailController = "/api/account/ConfirmEmail";

        public AccountService(IUnitOfWork uow,
            UserManager<User> userManager,
            IOptions<ApplicationSettings> applicationSettingsOption,
            IEmailService emailService,
            IFileService fileService,
            IUserProfileService userProfileService
            )
        {
            Database = uow;
            _userManager = userManager;
            _applicationSettingsOption = applicationSettingsOption.Value;
            _emailService = emailService;
            _fileService = fileService;
            _userProfileService = userProfileService;
        }

        public async Task<object> RegisterUser(RegisterViewModel model, string url)
        {
            var user = model.CreateUser();

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return null;

            var userProfile = new UserProfile { UserId = user.Id };
            _userProfileService.CreateUserProfile(userProfile);

            await _emailService.SendEmailAsync(user.Email, Constants.ConfirmationEmail_Subject,
                string.Format(Constants.ConfirmationEmail_Message, CreateCallbackUrl(user, url).GetAwaiter().GetResult()));
            return result;
        }

        private async Task<StringBuilder> CreateCallbackUrl(User user, string url)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var urlParams = new Dictionary<string, string>
            {
                { "userId", user.Id },
                { "code", HttpUtility.UrlEncode(code) }
            };
            return new CallbackUrlBuilder().Build(url, ConfirmEmailController, urlParams);
        }

        public async Task<OperationDetails> ConfirmEmail(User user, string code)
        {
            var success = await _userManager.ConfirmEmailAsync(user, code);
            return new OperationDetails(success.Succeeded, success.Succeeded
                ? Constants.Status_Success : Constants.Status_Error, string.Empty);
        }

        public async Task<object> LoginUser(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password) ||
                !await _userManager.IsEmailConfirmedAsync(user))
                return null;

            _fileService.SetUserFolder(user);
            return new JwtSecurityTokenBuilder()
                .Subject(user.Id).ExpiresInOneDay().SigningCredentials(_applicationSettingsOption.JWT_secret).Build();
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