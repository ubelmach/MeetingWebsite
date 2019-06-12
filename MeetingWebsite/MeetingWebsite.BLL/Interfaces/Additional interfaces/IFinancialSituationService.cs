using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public interface IFinancialSituationService
    {
        IEnumerable<FinancialSituation> GetAll();
    }
}