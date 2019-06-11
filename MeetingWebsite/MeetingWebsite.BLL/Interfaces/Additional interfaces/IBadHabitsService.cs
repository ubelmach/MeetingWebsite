using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IBadHabitsService
    {
        IEnumerable<BadHabits> GetAll();
    }
}