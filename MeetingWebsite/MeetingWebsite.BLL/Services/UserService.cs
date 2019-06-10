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
        private IPurposeService _purposeService { get; set; }
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork database,
            UserManager<User> userManager,
            IAccountService accountService,
            IPurposeService purposeService)
        {
            _database = database;
            _userManager = userManager;
            _accountService = accountService;
            _purposeService = purposeService;
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

                //if (!string.IsNullOrEmpty(editUser.PurposeOfDating))
                //{ userProfile.PurposeOfDating = editUser.PurposeOfDating; }
                //if (!string.IsNullOrEmpty(editUser.KnowledgeOfLanguages))
                //{ userProfile.KnowledgeOfLanguages = editUser.KnowledgeOfLanguages; }


                if (editUser.PurposeOfDating != null)
                {
                    foreach (var purpose in editUser.PurposeOfDating)
                    {
                        var newUserPurpose = new UserPurpose
                        {
                            UserProfileId = user.UserProfile.Id,
                            PurposeId = purpose
                        };
                        _purposeService.Update(newUserPurpose);
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