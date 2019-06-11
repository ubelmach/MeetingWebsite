using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IUserInterestsService
    {
        UserInterests AddInterests(UserInterests newUserInterests);
        void DeleteInterests(int id);
    }
}