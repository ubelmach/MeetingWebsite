using System;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserPurposeService : IUserPurposeService
    {
        private IUnitOfWork _database;
        public UserPurposeService(IUnitOfWork database)
        {
            _database = database;
        }

        public UserPurpose AddPurpose(UserPurpose newUserPurpose)
        {
            try
            {
                _database.UserPurposeRepository.Create(newUserPurpose);
                _database.Save();
                return newUserPurpose;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePurpose(int id)
        {
            var userPurpose = _database.UserPurposeRepository.Find(x => x.UserProfileId == id);

            foreach (var purpose in userPurpose)
            {
                _database.UserPurposeRepository.Delete(purpose.Id);
            }
            _database.Save();
        }
    }
}