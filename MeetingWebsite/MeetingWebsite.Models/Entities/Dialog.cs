using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class Dialog
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public virtual User Sender { get; set; }
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}