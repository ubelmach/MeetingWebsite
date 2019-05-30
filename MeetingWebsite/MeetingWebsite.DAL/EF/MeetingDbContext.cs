using System;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetingWebsite.DAL.EF
{
    public class MeetingDbContext : IdentityDbContext<User>
    {
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }

        public MeetingDbContext(DbContextOptions options)
            : base(options) { }
    }
}