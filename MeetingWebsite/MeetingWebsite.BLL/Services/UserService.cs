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
        private readonly IUnitOfWork _database;
        private readonly IAccountService _accountService;
        private readonly IUserPurposeService _userPurposeService;
        private readonly IUserLanguagesService _userLanguagesService;
        private readonly IUserBadHabitsService _userBadHabitsService;
        private readonly IUserInterestsService _userInterestsService;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork database,
            UserManager<User> userManager,
            IAccountService accountService,
            IUserPurposeService userPurposeService,
            IUserLanguagesService userLanguagesService,
            IUserBadHabitsService userBadHabitsService,
            IUserInterestsService userInterestsService)
        {
            _database = database;
            _userManager = userManager;
            _accountService = accountService;
            _userPurposeService = userPurposeService;
            _userLanguagesService = userLanguagesService;
            _userBadHabitsService = userBadHabitsService;
            _userInterestsService = userInterestsService;
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public async Task<EditUserProfileInformation> EditUserInformation(EditUserProfileInformation editUser)
        {
            var user = await _accountService.GetUser(editUser.Id);

            if (user == null || user.UserProfile == null)
                return null;

            var userProfile = user.UserProfile;

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

            if (editUser.BadHabits != null)
            {
                _userBadHabitsService.DeleteHabits(user.UserProfile.Id);
                foreach (var badHabit in editUser.BadHabits)
                {
                    var newUserBadHabits = new UserBadHabits
                    {
                        UserProfileId = user.UserProfile.Id,
                        BadHabitsId = badHabit
                    };
                    _userBadHabitsService.AddBadHabits(newUserBadHabits);
                }
                _database.Save();
            }

            if (editUser.Interests != null)
            {
                _userInterestsService.DeleteInterests(user.UserProfile.Id);
                foreach (var interest in editUser.Interests)
                {
                    var newUserInterest = new UserInterests
                    {
                        UserProfileId = user.UserProfile.Id,
                        InterestsId = interest
                    };
                    _userInterestsService.AddInterests(newUserInterest);
                }
                _database.Save();
            }

            await _userManager.UpdateAsync(user);
            return new EditUserProfileInformation(user);
        }
    }
}
