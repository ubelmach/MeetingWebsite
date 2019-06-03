using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingWebsite.DAL.Configuration
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasOne(a => a.FirstFriend)
                .WithMany(b => b.OutgoingFriendships)
                .HasForeignKey(c => c.FirstFriendId);

            builder.HasOne(a => a.SecondFriend)
                .WithMany(b => b.IncomingFriendships)
                .HasForeignKey(c => c.SecondFriendId);
        }
    }
}