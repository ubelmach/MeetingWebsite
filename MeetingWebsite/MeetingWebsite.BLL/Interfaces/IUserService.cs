using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;

namespace MeetingWebsite.BLL.Services
{
    public interface IUserService
    {
        Task<EditUserProfileInformation> EditUserInformation(EditUserProfileInformation editUser);
        void Dispose();
    }
}