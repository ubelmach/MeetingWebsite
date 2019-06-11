using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class BadHabitsService : IBadHabitsService
    {
        private IUnitOfWork _database;

        public BadHabitsService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<BadHabits> GetAll()
        {
            return _database.BadHabitsRepository.GetAll();
        }
    }
}