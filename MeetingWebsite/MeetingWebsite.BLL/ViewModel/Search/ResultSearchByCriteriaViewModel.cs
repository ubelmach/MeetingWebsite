using System;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ResultSearchByCriteriaViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public string Avatar { get; set; }

        public ResultSearchByCriteriaViewModel(User user)
        {
            UserId = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = DateTime.Today.Year - user.Birthday.Year;

            if (user.Avatar != null)
            {
                Avatar = user.HomeDir + user.Avatar.Path;
            }
            else
            {
                Avatar = "/File/Nophoto.jpg";
            }
        }
        public static IEnumerable<ResultSearchByCriteriaViewModel> MapToViewModels(List<User> users)
        {
            foreach (var user in users)
            {
                yield return new ResultSearchByCriteriaViewModel(user);
            }
        }
    }
}