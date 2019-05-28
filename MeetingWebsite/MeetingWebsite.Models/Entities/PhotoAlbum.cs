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
        public string IdUser { get; set; }

        public string Name { get; set; }

        public virtual List<File> File { get; set; }
        public virtual User User { get; set; }
    }
}