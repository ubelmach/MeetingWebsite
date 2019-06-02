using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class FriendService : IFriendService
    {
        private IUnitOfWork _database;

        public FriendService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<Friendship> FindFriendCurrentUser(string userId)
        {
            var friend = _database.FriendRepository
                .Find(x => x.FirstFriendId == userId || x.SecondFriendId == userId);

            return friend;
        }

        public ShowInformationFriendViewModel ShowInformationFriend(Task<User> friend)
        {
            var showInfoFriend = new ShowInformationFriendViewModel
            {
                FirstName = friend.Result.FirstName,
                LastName = friend.Result.LastName,
                Birthday = friend.Result.Birthday,
                Gender = friend.Result.FirstName,
                PurposeOfDating = friend.Result.UserProfile.PurposeOfDating,
                MaritalStatus = friend.Result.UserProfile.MaritalStatus,
                Height = friend.Result.UserProfile.Height,
                Weight = friend.Result.UserProfile.Education,
                Education = friend.Result.UserProfile.Education,
                Nationality = friend.Result.UserProfile.Nationality,
                ZodiacSign = friend.Result.UserProfile.ZodiacSign.ToString(),
                KnowledgeOfLanguages = friend.Result.UserProfile.KnowledgeOfLanguages,
                BadHabits = friend.Result.UserProfile.BadHabits,
                FinancialSituation = friend.Result.UserProfile.FinancialSituation,
                Interests = friend.Result.UserProfile.Interests,
                Avatar = friend.Result.Avatar.Path
            };

            return showInfoFriend;
        }
    }
}