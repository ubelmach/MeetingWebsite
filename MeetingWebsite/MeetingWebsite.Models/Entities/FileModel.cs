using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Message")]
        public int MessageId { get; set; }
        public virtual Message Message { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public virtual PhotoAlbum Album { get; set; }
        
        public string Name { get; set; }
        public string Path { get; set; }
    }
}