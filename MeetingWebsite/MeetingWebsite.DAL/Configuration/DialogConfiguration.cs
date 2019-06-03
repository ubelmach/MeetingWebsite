using MeetingWebsite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingWebsite.DAL.Configuration
{
    public class DialogConfiguration : IEntityTypeConfiguration<Dialog>
    {
        public void Configure(EntityTypeBuilder<Dialog> builder)
        {
            builder.HasOne(a => a.Sender)
                .WithMany(b => b.OutgoingMessages)
                .HasForeignKey(c => c.SenderId);

            builder.HasOne(a => a.Receiver)
                .WithMany(b => b.IncomingMessages)
                .HasForeignKey(c => c.ReceiverId);
        }
    }
}