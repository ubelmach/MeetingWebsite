using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IUserPurposeService
    {
        UserPurpose AddPurpose(UserPurpose newUserPurpose);
        void DeletePurpose(int id);
    }
}