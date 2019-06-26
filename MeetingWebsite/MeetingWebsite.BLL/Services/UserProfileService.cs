using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _database;

        public UserProfileService(IUnitOfWork database)
        {
            _database = database;
        }

        public void CreateUserProfile(UserProfile userProfile)
        {
            _database.UserProfileRepository.Create(userProfile);
            _database.Save();
        }
    }
}