using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace MeetingWebsite.Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey("File")]
        public int IdFile { get; set; }
        public virtual List<FileModel> Files { get; set; }

        [ForeignKey("Dialog")]
        public int IdDialog { get; set; }
        public virtual Dialog Dialog { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool New { get; set; }

    }
}