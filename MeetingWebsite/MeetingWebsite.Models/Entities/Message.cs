using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public string IdSender { get; set; }

        [ForeignKey("Receiver")]
        public string IdReceiver { get; set; }

        [ForeignKey("File")]
        public int IdFile { get; set; }

        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public bool New { get; set; }

        public virtual User User { get; set; }
        public virtual File File { get; set; }
    }
}