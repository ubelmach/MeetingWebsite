using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IUserService
    {
        Task EditUserInformation(EditUserProfileInformation editUser);
    }
}