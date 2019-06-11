using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IUserLanguagesService
    {
        UserLanguages AddLanguages(UserLanguages newUserLanguages);
        void DeleteLanguage(int id);
    }
}