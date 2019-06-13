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
        private IUnitOfWork Database { get; set; }
        private IAccountService AccountService { get; set; }
        private IUserPurposeService UserPurposeService { get; set; }
        private IUserLanguagesService UserLanguagesService { get; set; }
        private IUserBadHabitsService UserBadHabitsService { get; set; }
        private IUserInterestsService UserInterestsService { get; set; }

        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork database,
            UserManager<User> userManager,
            IAccountService accountService,
            IUserPurposeService userPurposeService,
            IUserLanguagesService userLanguagesService,
            IUserBadHabitsService userBadHabitsService,
            IUserInterestsService userInterestsService)
        {
            Database = database;
            _userManager = userManager;
            AccountService = accountService;
            UserPurposeService = userPurposeService;
            UserLanguagesService = userLanguagesService;
            UserBadHabitsService = userBadHabitsService;
            UserInterestsService = userInterestsService;
        }

        public async Task<EditUserProfileInformation> EditUserInformation(EditUserProfileInformation editUser)
        {
            var user = await AccountService.GetUser(editUser.Id);

            if (user == null || user.UserProfile == null)
                return null;

            var userProfile = user.UserProfile;

            try
            {
                if (!string.IsNullOrEmpty(editUser.FirstName))
                { user.FirstName = editUser.FirstName; }

                if (!string.IsNullOrEmpty(editUser.LastName))
                { user.LastName = editUser.LastName; }

                if (!string.IsNullOrEmpty(editUser.Height))
                { userProfile.Height = editUser.Height; }

                if (!string.IsNullOrEmpty(editUser.Weight))
                { userProfile.Weight = editUser.Weight; }

                if (!string.IsNullOrEmpty(editUser.Birthday.ToString(CultureInfo.InvariantCulture)))
                { user.Birthday = editUser.Birthday; }

                if (!string.IsNullOrEmpty(editUser.ZodiacSign.ToString()))
                { userProfile.ZodiacSignId = editUser.ZodiacSign; }

                if (!string.IsNullOrEmpty(editUser.Nationality.ToString()))
                { userProfile.NationalityId = editUser.Nationality; }

                if (!string.IsNullOrEmpty(editUser.FinancialSituation.ToString()))
                { userProfile.FinancialSituationId = editUser.FinancialSituation; }

                user.AnonymityMode = editUser.AnonymityMode;

                if (!string.IsNullOrEmpty(editUser.Genders.ToString()))
                {
                    user.GenderId = editUser.Genders;
                }

                if (!string.IsNullOrEmpty(editUser.Education.ToString()))
                {
                    userProfile.EducationId = editUser.Education;
                }

                if (editUser.PurposeOfDating != null)
                {
                    UserPurposeService.DeletePurpose(user.UserProfile.Id);
                    foreach (var purpose in editUser.PurposeOfDating)
                    {
                        var newUserPurpose = new UserPurpose
                        {
                            UserProfileId = user.UserProfile.Id,
                            PurposeId = purpose
                        };
                        UserPurposeService.AddPurpose(newUserPurpose);
                    }
                    Database.Save();
                }

                if (editUser.KnowledgeOfLanguages != null)
                {
                    UserLanguagesService.DeleteLanguage(user.UserProfile.Id);
                    foreach (var language in editUser.KnowledgeOfLanguages)
                    {
                        var newUserLanguages = new UserLanguages
                        {
                            UserProfileId = user.UserProfile.Id,
                            LanguageId = language
                        };
                        UserLanguagesService.AddLanguages(newUserLanguages);
                    }
                    Database.Save();
                }

                if (editUser.BadHabits != null)
                {
                    UserBadHabitsService.DeleteHabits(user.UserProfile.Id);
                    foreach (var badHabit in editUser.BadHabits)
                    {
                        var newUserBadHabits = new UserBadHabits
                        {
                            UserProfileId = user.UserProfile.Id,
                            BadHabitsId = badHabit
                        };
                        UserBadHabitsService.AddBadHabits(newUserBadHabits);
                    }
                    Database.Save();
                }

                if (editUser.Interests != null)
                {
                    UserInterestsService.DeleteInterests(user.UserProfile.Id);
                    foreach (var interest in editUser.Interests)
                    {
                        var newUserInterest = new UserInterests
                        {
                            UserProfileId = user.UserProfile.Id,
                            InterestsId = interest
                        };
                        UserInterestsService.AddInterests(newUserInterest);
                    }
                    Database.Save();
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
            Database.Dispose();
        }
    }
}