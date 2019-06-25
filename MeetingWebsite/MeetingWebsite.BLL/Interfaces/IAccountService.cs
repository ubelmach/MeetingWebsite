using System.Threading.Tasks;
using MeetingWebsite.BLL.Infrastructure;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeetingWebsite.BLL.Services
{
    public interface IAccountService
    {
        Task<object> RegisterUser(RegisterViewModel model, string url);
        Task<OperationDetails> ConfirmEmail(User user, string code);
        Task<object> LoginUser(LoginViewModel model);
        Task<User> GetUser(string userId);
        Task<object> UserForgotPassword(ForgotPasswordViewModel model, string url);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel model);
        Task<IdentityResult> ChangePassword(ChangePasswordViewModel model, string userId);
    }
}