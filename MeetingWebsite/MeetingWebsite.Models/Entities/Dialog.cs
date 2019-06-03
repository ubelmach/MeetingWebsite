﻿using System;
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

        [NotMapped]
        public virtual User Sender { get; set; }

        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }

        [NotMapped]
        public virtual User Receiver { get; set; }

        public DateTime Date { get; set; }
    }
}