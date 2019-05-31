using System;
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

        public UserService(IUnitOfWork database,
            IAccountService accountService,
            IFileService fileService)
        {
            _database = _database;
            _accountService = accountService;
        }

        public async Task<User> EditUserInformation(EditUserProfileInformation editUser)
        {
            var user = await _accountService.GetUser(editUser.Id);

            try
            {
                user.FirstName = editUser.Firstname;
                user.LastName = editUser.Lastname;
                user.Birthday = editUser.Birthday;
                user.Gender = editUser.Gender;
                user.UserProfile.ZodiacSign = editUser.ZodiacSign;

                if (editUser.PurposeOfDating != null)
                {
                    user.UserProfile.PurposeOfDating = editUser.PurposeOfDating;
                }

                if (editUser.MaritalStatus != null)
                {
                    user.UserProfile.MaritalStatus = editUser.MaritalStatus;
                }

                if (editUser.Height != null)
                {
                    user.UserProfile.Height = editUser.Height;
                }

                if (editUser.Weight != null)
                {
                    user.UserProfile.Weight = editUser.Weight;
                }

                if (editUser.Education != null)
                {
                    user.UserProfile.Education = editUser.Education;
                }

                if (editUser.Nationality != null)
                {
                    user.UserProfile.Nationality = editUser.Nationality;
                }

                if (editUser.KnowledgeOfLanguages != null)
                {
                    user.UserProfile.KnowledgeOfLanguages = editUser.KnowledgeOfLanguages;
                }

                if (editUser.BadHabits != null)
                {
                    user.UserProfile.BadHabits = editUser.BadHabits;
                }

                if (editUser.FinancialSituation != null)
                {
                    user.UserProfile.FinancialSituation = editUser.FinancialSituation;
                }

                if (editUser.Interests != null)
                {
                    user.UserProfile.Interests = editUser.Interests;
                }

                user.UserProfile.AnonymityMode = editUser.AnonymityMode;

                _database.UserRepository.Update(user);
                _database.Save();
                return user;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}