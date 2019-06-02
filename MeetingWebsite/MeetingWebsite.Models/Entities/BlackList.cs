using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class BlackList
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CurrentUser")]
        public string CurrentUserId { get; set; }

        [NotMapped]
        public virtual User CurrentUser { get; set; }

        [ForeignKey("Whom")]
        public string WhomId { get; set; }

        [NotMapped]
        public virtual User Whom { get; set; }

        public DateTime Date { get; set; }
    }
}