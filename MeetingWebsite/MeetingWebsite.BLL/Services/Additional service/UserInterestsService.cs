using System;
using System.Runtime.InteropServices;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserInterestsService: IUserInterestsService
    {
        private IUnitOfWork _database;

        public UserInterestsService(IUnitOfWork database)
        {
            _database = database;
        }

        public UserInterests AddInterests(UserInterests newUserInterests)
        {
            try
            {
                _database.UserInterestsRepository.Create(newUserInterests);
                _database.Save();
                return newUserInterests;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteInterests(int id)
        {
            var userInterests = _database.UserInterestsRepository.Find(x => x.UserProfileId == id);

            foreach (var interest in userInterests)
            {
                _database.UserInterestsRepository.Delete(interest.Id);
            }
            _database.Save();
        }
    }
}