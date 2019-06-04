using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task EditUserInformation(EditUserProfileInformation editUser)
        {
            var user = await _accountService.GetUser(editUser.Id);
            var userProfile = user.UserProfile;

            try
            {
                //if (!string.IsNullOrEmpty(editUser.Firstname))
                //{
                user.FirstName = editUser.Firstname;
                //}

                //if (!string.IsNullOrEmpty(editUser.Lastname))
                //{
                user.LastName = editUser.Lastname;
                //}

                //if (!string.IsNullOrEmpty(editUser.Gender.ToString()))
                //{
                user.Gender = editUser.Gender;
                //}

                //if (!string.IsNullOrEmpty(editUser.Birthday.ToString(CultureInfo.InvariantCulture)))
                //{
                user.Birthday = editUser.Birthday;
                //}

                //if (!string.IsNullOrEmpty(editUser.ZodiacSign))
                //{
                userProfile.ZodiacSign = editUser.ZodiacSign;
                //}

                //if (!string.IsNullOrEmpty(editUser.PurposeOfDating))
                //{
                userProfile.PurposeOfDating = editUser.PurposeOfDating;
                //}

                //if (!string.IsNullOrEmpty(editUser.MaritalStatus))
                //{
                userProfile.MaritalStatus = editUser.MaritalStatus;
                //}

                //if (!string.IsNullOrEmpty(editUser.Height))
                //{
                userProfile.Height = editUser.Height;
                //}

                //if (!string.IsNullOrEmpty(editUser.Weight))
                //{
                userProfile.Weight = editUser.Weight;
                //}

                //if (!string.IsNullOrEmpty(editUser.Education))
                //{
                userProfile.Education = editUser.Education;
                //}

                //if (!string.IsNullOrEmpty(editUser.Nationality))
                //{
                userProfile.Nationality = editUser.Nationality;
                //}

                //if (!string.IsNullOrEmpty(editUser.KnowledgeOfLanguages))
                //{
                userProfile.KnowledgeOfLanguages = editUser.KnowledgeOfLanguages;
                //}

                //if (!string.IsNullOrEmpty(editUser.BadHabits))
                //{
                userProfile.BadHabits = editUser.BadHabits;
                //}

                //if (!string.IsNullOrEmpty(editUser.FinancialSituation))
                //{
                userProfile.FinancialSituation = editUser.FinancialSituation;
                //}

                //if (!string.IsNullOrEmpty(editUser.Interests))
                //{
                userProfile.Interests = editUser.Interests;
                //}

                user.AnonymityMode = editUser.AnonymityMode;

                _database.UserRepository.Update(user);
                _database.UserProfileRepository.Update(userProfile);
                _database.Save();
            }

            catch (Exception ex)
            {
                throw ex;
                //return ex.Message;
            }
        }
    }
}