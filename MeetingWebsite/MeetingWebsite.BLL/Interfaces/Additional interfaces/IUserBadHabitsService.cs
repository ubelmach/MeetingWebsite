using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IUserBadHabitsService
    {
        UserBadHabits AddBadHabits(UserBadHabits newUserHabits);
        void DeleteHabits(int id);
    }
}