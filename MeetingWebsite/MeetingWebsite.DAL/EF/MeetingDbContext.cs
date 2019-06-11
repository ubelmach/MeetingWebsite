using MeetingWebsite.DAL.Configuration;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.EF
{
    public class MeetingDbContext : IdentityDbContext<User>
    {
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PurposeOfDating> PurposeOfDatings { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<UserLanguages> UserLanguages { get; set; }
        public DbSet<UserPurpose> UserPurposes { get; set; }

        public MeetingDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FriendshipConfiguration());
            modelBuilder.ApplyConfiguration(new BlacklistConfiguration());
            modelBuilder.ApplyConfiguration(new DialogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}