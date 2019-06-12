using System.Collections.Generic;
using MeetingWebsite.Models.Entities;
using MeetingWebsite.Models.EntityEnums;

namespace MeetingWebsite.BLL.Services
{
    public interface IGenderService
    {
        IEnumerable<Gender> GetAll();
    }
}