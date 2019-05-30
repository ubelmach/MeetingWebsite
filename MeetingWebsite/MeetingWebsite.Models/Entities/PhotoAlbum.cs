using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class PhotoAlbum
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [NotMapped]
        public virtual User User { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual List<File> Files { get; set; }
    }
}