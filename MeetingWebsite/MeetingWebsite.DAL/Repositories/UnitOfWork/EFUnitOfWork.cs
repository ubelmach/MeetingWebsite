using System;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly MeetingDbContext _db;
        private UserRepository _userRepository;
        private UserProfileRepository _userProfileRepository;
        private FileRepository _fileRepository;
        private FriendshipRepository _friendshipRepository;
        private MessageRepository _messageRepository;
        private AlbumRepository _albumRepository;
        private BlacklistRepository _blacklistRepository;

        private PurposeRepository _purposeRepository;
        private UserPurposeRepository _userPurposeRepository;
        private LanguageRepository _languageRepository;
        private UserLanguagesRepository _userLanguagesRepository;
        private BadHabitsRepository _badHabitsRepository;
        private UserBadHabitsRepository _userBadHabitsRepository;
        private InterestsRepository _interestsRepository;
        private UserInterestsRepository _userInterestsRepository;

        private GenderRepository _genderRepository;
        private EducationRepository _educationRepository;
        private FinancialSituationRepository _financialSituationRepository;
        private NationalityRepository _nationalityRepository;
        private ZodiacSignsRepository _zodiacSignsRepository;

        public EfUnitOfWork(DbContextOptions options)
        {
            _db = new MeetingDbContext(options);
        }

        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = new UserRepository(_db));

        public IRepository<UserProfile> UserProfileRepository =>
            _userProfileRepository ?? (_userProfileRepository = new UserProfileRepository(_db));

        public IRepository<FileModel> FileRepository => 
            _fileRepository ?? (_fileRepository = new FileRepository(_db));

        public IRepository<Friendship> FriendRepository =>
            _friendshipRepository ?? (_friendshipRepository = new FriendshipRepository(_db));

        public IRepository<Message> MessageRepository =>
            _messageRepository ?? (_messageRepository = new MessageRepository(_db));

        public IRepository<PhotoAlbum> AlbumRepository =>
            _albumRepository ?? (_albumRepository = new AlbumRepository(_db));

        public IRepository<BlackList> BlacklistRepository =>
            _blacklistRepository ?? (_blacklistRepository = new BlacklistRepository(_db));

        public IRepository<PurposeOfDating> PurposeRepository =>
            _purposeRepository ?? (_purposeRepository = new PurposeRepository(_db));

        public IRepository<UserPurpose> UserPurposeRepository =>
            _userPurposeRepository ?? (_userPurposeRepository = new UserPurposeRepository(_db));

        public IRepository<Languages> LanguageRepository =>
            _languageRepository ?? (_languageRepository = new LanguageRepository(_db));

        public IRepository<UserLanguages> UserLanguagesRepository =>
            _userLanguagesRepository ?? (_userLanguagesRepository = new UserLanguagesRepository(_db));

        public IRepository<BadHabits> BadHabitsRepository =>
            _badHabitsRepository ?? (_badHabitsRepository = new BadHabitsRepository(_db));

        public IRepository<UserBadHabits> UserBadHabitsRepository =>
            _userBadHabitsRepository ?? (_userBadHabitsRepository = new UserBadHabitsRepository(_db));

        public IRepository<Interests> InterestsRepository =>
            _interestsRepository ?? (_interestsRepository = new InterestsRepository(_db));

        public IRepository<UserInterests> UserInterestsRepository =>
            _userInterestsRepository ?? (_userInterestsRepository = new UserInterestsRepository(_db));

        public IRepository<Gender> GenderRepository => 
            _genderRepository ?? (_genderRepository = new GenderRepository(_db));

        public IRepository<Education> EducationRepository =>
         _educationRepository ?? (_educationRepository = new EducationRepository(_db));

        public IRepository<FinancialSituation> FinancialSituationRepository =>
            _financialSituationRepository ?? (_financialSituationRepository = new FinancialSituationRepository(_db));

        public IRepository<Nationality> NationalityRepository =>
            _nationalityRepository ?? (_nationalityRepository = new NationalityRepository(_db));

        public IRepository<ZodiacSigns> ZodiacSignsRepository =>
            _zodiacSignsRepository ?? (_zodiacSignsRepository = new ZodiacSignsRepository(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                _db.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
         {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}