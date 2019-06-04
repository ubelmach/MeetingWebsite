﻿using System;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        public IUnitOfWork _database;

        public UserProfileService(IUnitOfWork database)
        {
            _database = database;
        }

        public void CreateUserProfile(UserProfile userProfile)
        {
            try
            {
                _database.UserProfileRepository.Create(userProfile);
                _database.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}