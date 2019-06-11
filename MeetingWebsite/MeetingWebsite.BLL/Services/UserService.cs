using System;
using System.Globalization;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeetingWebsite.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _database { get; set; }
        private IAccountService _accountService { get; set; }
        private IUserPurposeService _userPurposeService { get; set; }
        private IUserLanguagesService _userLanguagesService { get; set; }
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork database,
            UserManager<User> userManager,
            IAccountService accountService,
            IUserPurposeService userPurposeService,
            IUserLanguagesService userLanguagesService)
        {
            _database = database;
            _userManager = userManager;
            _accountService = accountService;
            _userPurposeService = userPurposeService;
            _userLanguagesService = userLanguagesService;
        }

        public async Task<EditUserProfileInformation> EditUserInformation(EditUserProfileInformation editUser)
        {
            var user = await _accountService.GetUser(editUser.Id);

            if (user == null || user.UserProfile == null)
                return null;

            var userProfile = user.UserProfile;

            try
            {
                if (!string.IsNullOrEmpty(editUser.FirstName))
                { user.FirstName = editUser.FirstName; }
                if (!string.IsNullOrEmpty(editUser.LastName))
                { user.LastName = editUser.LastName; }
                if (!string.IsNullOrEmpty(editUser.Genders.ToString()))
                { user.Gender = editUser.Genders; }
                if (!string.IsNullOrEmpty(editUser.Birthday.ToString(CultureInfo.InvariantCulture)))
                { user.Birthday = editUser.Birthday; }
                if (!string.IsNullOrEmpty(editUser.ZodiacSign.ToString()))
                { userProfile.ZodiacSign = editUser.ZodiacSign; }
                if (!string.IsNullOrEmpty(editUser.MaritalStatus))
                { userProfile.MaritalStatus = editUser.MaritalStatus; }
                if (!string.IsNullOrEmpty(editUser.Height))
                { userProfile.Height = editUser.Height; }
                if (!string.IsNullOrEmpty(editUser.Weight))
                { userProfile.Weight = editUser.Weight; }
                if (!string.IsNullOrEmpty(editUser.Education))
                { userProfile.Education = editUser.Education; }
                if (!string.IsNullOrEmpty(editUser.Nationality))
                { userProfile.Nationality = editUser.Nationality; }
                if (!string.IsNullOrEmpty(editUser.BadHabits))
                { userProfile.BadHabits = editUser.BadHabits; }
                if (!string.IsNullOrEmpty(editUser.FinancialSituation))
                { userProfile.FinancialSituation = editUser.FinancialSituation; }
                if (!string.IsNullOrEmpty(editUser.Interests))
                { userProfile.Interests = editUser.Interests; }
                user.AnonymityMode = editUser.AnonymityMode;

                if (editUser.PurposeOfDating != null)
                {
                    _userPurposeService.DeletePurpose(user.UserProfile.Id);
                    foreach (var purpose in editUser.PurposeOfDating)
                    {
                        var newUserPurpose = new UserPurpose
                        {
                            UserProfileId = user.UserProfile.Id,
                            PurposeId = purpose
                        };
                        _userPurposeService.AddPurpose(newUserPurpose);
                    }
                    _database.Save();
                }

                if (editUser.KnowledgeOfLanguages != null)
                {
                    _userLanguagesService.DeleteLanguage(user.UserProfile.Id);
                    foreach (var language in editUser.KnowledgeOfLanguages)
                    {
                        var newUserLanguages = new UserLanguages
                        {
                            UserProfileId = user.UserProfile.Id,
                            LanguageId = language
                        };
                        _userLanguagesService.AddLanguages(newUserLanguages);
                    }
                    _database.Save();
                }

                await _userManager.UpdateAsync(user);

                var result = new EditUserProfileInformation(user);
                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}