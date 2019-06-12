using System;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Friendship> FriendRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<UserProfile> UserProfileRepository { get; }
        IRepository<FileModel> FileRepository { get; }
        IRepository<PhotoAlbum> AlbumRepository { get; }
        IRepository<BlackList> BlacklistRepository { get; }
        IUserRepository UserRepository { get; }

        IRepository<PurposeOfDating> PurposeRepository { get; }
        IRepository<UserPurpose> UserPurposeRepository { get; }

        IRepository<Languages> LanguageRepository { get; }
        IRepository<UserLanguages> UserLanguagesRepository { get; }

        IRepository<BadHabits> BadHabitsRepository { get; }
        IRepository<UserBadHabits> UserBadHabitsRepository { get; }

        IRepository<Interests> InterestsRepository { get; }
        IRepository<UserInterests> UserInterestsRepository { get; }

        IRepository<Gender> GenderRepository { get; }
        IRepository<Education> EducationRepository { get; }
        IRepository<FinancialSituation> FinancialSituationRepository { get; }
        IRepository<Nationality> NationalityRepository { get; }
        IRepository<ZodiacSigns> ZodiacSignsRepository { get; }
        void Save();
    }
}