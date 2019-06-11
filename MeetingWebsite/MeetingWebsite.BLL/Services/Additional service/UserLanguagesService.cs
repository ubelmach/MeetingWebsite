using System;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserLanguagesService : IUserLanguagesService
    {
        private IUnitOfWork _database;

        public UserLanguagesService(IUnitOfWork database)
        {
            _database = database;
        }

        public UserLanguages AddLanguages(UserLanguages newUserLanguages)
        {
            try
            {
                _database.UserLanguagesRepository.Create(newUserLanguages);
                _database.Save();
                return newUserLanguages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLanguage(int id)
        {
            var userLanguage = _database.UserLanguagesRepository.Find(x => x.UserProfileId == id);

            foreach (var language in userLanguage)
            {
                _database.UserLanguagesRepository.Delete(language.Id);
            }
            _database.Save();
        }
    }
}