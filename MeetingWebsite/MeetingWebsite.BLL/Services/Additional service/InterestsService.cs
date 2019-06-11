using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class InterestsService : IInterestsService
    {
        private IUnitOfWork _database;

        public InterestsService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<Interests> GetAll()
        {
            return _database.InterestsRepository.GetAll();
        }
    }
}