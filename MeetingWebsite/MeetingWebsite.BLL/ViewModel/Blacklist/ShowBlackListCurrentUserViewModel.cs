using MeetingWebsite.Models.Entities;
using System;
using System.Collections.Generic;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowBlackListCurrentUserViewModel
    {
        public int Id { get; set; }
        public string BannedUserId { get; set; }
        public int BlacklistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }

        public ShowBlackListCurrentUserViewModel(BlackList blackList)
        {
            Id = blackList.Id;
            BannedUserId = blackList.WhomId;
            BlacklistId = blackList.Id;
            FirstName = blackList.Whom.FirstName;
            LastName = blackList.Whom.LastName;
            Date = blackList.Date;
        }

        public static IEnumerable<ShowBlackListCurrentUserViewModel> MapToViewModels(List<BlackList> blackLists)
        {
            foreach (var blackList in blackLists)
            {
                yield return new ShowBlackListCurrentUserViewModel(blackList);
            }
        }
    }
}