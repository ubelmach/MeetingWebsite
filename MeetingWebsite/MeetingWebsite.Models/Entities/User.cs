using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string HomeDir { get; set; }

        [NotMapped]
        public virtual List<Friendship> IncomingFriendships { get; set; }

        [NotMapped]
        public virtual List<Friendship> OutgoingFriendships { get; set; }

        [NotMapped]
        public virtual List<Message> IncomingMessages { get; set; }

        [NotMapped]
        public virtual List<Message> OutgoingMessages { get; set; }

        [NotMapped]
        public virtual List<BlackList> WhomTheUserAdded { get; set; }

        [NotMapped]
        public virtual List<BlackList> WhoAddedCurrentUser { get; set; }

        [ForeignKey("Avatar")]
        public int AvatarId { get; set; }

        [NotMapped]
        public virtual FileModel Avatar { get; set; }

        [NotMapped]
        public virtual UserProfile UserProfile { get; set; }

        [NotMapped]
        public virtual List<PhotoAlbum> PhotoAlbums { get; set; }
    }
}