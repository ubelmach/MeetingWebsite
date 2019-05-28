using System.Threading.Tasks;
using MeetingWebsite.BLL.Infrastructure;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<object> RegisterUser(RegisterViewModel model, string url);
        Task<OperationDetails> ConfirmEmail(User user, string code);
        Task<object> LoginUser(LoginViewModel model);
        Task<User> GetUser(string userId);
        void Dispose();
    }
}