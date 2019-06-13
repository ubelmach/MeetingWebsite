using MeetingWebsite.Models.Entities;
using System;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowBlackListCurrentUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public ShowBlackListCurrentUserViewModel(BlackList blackList)
        {
            FirstName = blackList.Whom.FirstName;
            LastName = blackList.Whom.LastName;
            Date = blackList.Date;
        }
    }
}