using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [NotMapped]
        public virtual User User { get; set; }

        [ForeignKey("Message")]
        public int MessageId { get; set; }

        [NotMapped]
        public virtual Message Message { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
    }
}