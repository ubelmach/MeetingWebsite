﻿using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class EducationService : IEducationService
    {
        private IUnitOfWork _database;

        public EducationService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<Education> GetAll()
        {
           return _database.EducationRepository.GetAll();
        }
    }
}