using System;
using System.Globalization;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _database { get; set; }
        private readonly IAccountService _accountService;
        private readonly IUserProfileService _userProfileService;

        public UserService(IUnitOfWork database,
            IAccountService accountService,
            IUserProfileService userProfileService)
        {
            _database = _database;
            _accountService = accountService;
            _userProfileService = userProfileService;
        }

        public async Task<object> EditUserInformation(EditUserProfileInformation editUser)
        {
            var user = await _accountService.GetUser(editUser.Id);

            try
            {
                if (!string.IsNullOrEmpty(editUser.Firstname))
                {
                    user.FirstName = editUser.Firstname;
                }

                if (!string.IsNullOrEmpty(editUser.Lastname))
                {
                    user.LastName = editUser.Lastname;
                }

                if (!string.IsNullOrEmpty(editUser.Gender.ToString()))
                {
                    user.Gender = editUser.Gender;
                }

                if (!string.IsNullOrEmpty(editUser.ZodiacSign))
                {
                    user.UserProfile.ZodiacSign = editUser.ZodiacSign;
                }

                if (!string.IsNullOrEmpty(editUser.Birthday.ToString(CultureInfo.InvariantCulture)))
                {
                    user.Birthday = editUser.Birthday;
                }

                if (!string.IsNullOrEmpty(editUser.PurposeOfDating))
                {
                    user.UserProfile.PurposeOfDating = editUser.PurposeOfDating;
                }

                if (!string.IsNullOrEmpty(editUser.MaritalStatus))
                {
                    user.UserProfile.MaritalStatus = editUser.MaritalStatus;
                }

                if (!string.IsNullOrEmpty(editUser.Height))
                {
                    user.UserProfile.Height = editUser.Height;
                }

                if (!string.IsNullOrEmpty(editUser.Weight))
                {
                    user.UserProfile.Weight = editUser.Weight;
                }

                if (!string.IsNullOrEmpty(editUser.Education))
                {
                    user.UserProfile.Education = editUser.Education;
                }

                if (!string.IsNullOrEmpty(editUser.Nationality))
                {
                    user.UserProfile.Nationality = editUser.Nationality;
                }

                if (!string.IsNullOrEmpty(editUser.KnowledgeOfLanguages))
                {
                    user.UserProfile.KnowledgeOfLanguages = editUser.KnowledgeOfLanguages;
                }

                if (!string.IsNullOrEmpty(editUser.BadHabits))
                {
                    user.UserProfile.BadHabits = editUser.BadHabits;
                }

                if (!string.IsNullOrEmpty(editUser.FinancialSituation))
                {
                    user.UserProfile.FinancialSituation = editUser.FinancialSituation;
                }

                if (!string.IsNullOrEmpty(editUser.Interests))
                {
                    user.UserProfile.Interests = editUser.Interests;
                }

                user.AnonymityMode = editUser.AnonymityMode;

                _database.UserRepository.Update(user);
                _database.UserProfileRepository.Update(user.UserProfile);
                _database.Save();
                return user;
            }

            catch (Exception ex)
            {
                //throw ex;
                return ex.Message;
            }
        }
    }
}