using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingWebsite.DAL.Configuration
{
    public class BlacklistConfiguration : IEntityTypeConfiguration<BlackList>
    {
        public void Configure(EntityTypeBuilder<BlackList> builder)
        {
            builder.HasOne(a => a.CurrentUser)
                .WithMany(b => b.WhoAddedCurrentUser)
                .HasForeignKey(c => c.CurrentUserId);

            builder.HasOne(a => a.Whom)
                .WithMany(b => b.WhomTheUserAdded)
                .HasForeignKey(c => c.WhomId);
        }
    }
}