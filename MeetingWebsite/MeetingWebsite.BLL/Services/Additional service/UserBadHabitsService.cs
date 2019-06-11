using System;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class UserBadHabitsService : IUserBadHabitsService
    {
        private IUnitOfWork _database;

        public UserBadHabitsService(IUnitOfWork database)
        {
            _database = database;
        }

        public UserBadHabits AddBadHabits(UserBadHabits newUserHabits)
        {
            try
            {
                _database.UserBadHabitsRepository.Create(newUserHabits);
                _database.Save();
                return newUserHabits;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteHabits(int id)
        {
            var userBadHabits = _database.UserBadHabitsRepository.Find(x => x.UserProfileId == id);

            foreach (var badHabit in userBadHabits)
            {
                _database.UserBadHabitsRepository.Delete(badHabit.Id);
            }
            _database.Save();
        }
    }
}