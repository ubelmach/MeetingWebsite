using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MeetingWebsite.Models.EntityEnums;
using Microsoft.AspNetCore.Identity;

namespace MeetingWebsite.Models.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }
        public bool AnonymityMode { get; set; }
        public string HomeDir { get; set; }

        [ForeignKey("Avatar")]
        public int? AvatarId { get; set; }
        public virtual FileModel Avatar { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual List<PhotoAlbum> PhotoAlbums { get; set; }

        public virtual List<Friendship> IncomingFriendships { get; set; }
        public virtual List<Friendship> OutgoingFriendships { get; set; }

        public virtual List<Dialog> IncomingMessages { get; set; }
        public virtual List<Dialog> OutgoingMessages { get; set; }

        public virtual List<BlackList> WhomTheUserAdded { get; set; }
        public virtual List<BlackList> WhoAddedCurrentUser { get; set; }

        public User()
        {
            IncomingFriendships = new List<Friendship>();
            OutgoingFriendships = new List<Friendship>();

            IncomingMessages = new List<Dialog>();
            OutgoingMessages = new List<Dialog>();

            WhomTheUserAdded = new List<BlackList>();
            WhoAddedCurrentUser = new List<BlackList>();
        }
    }
}